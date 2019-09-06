(function () {
    const $inputs = document.querySelectorAll('.js-input')
    const $stations = document.querySelectorAll('.js-station');
    const $submitBtn = document.querySelector('#submit');

    $inputs.forEach(item => {
        item.addEventListener('blur', () => {
            if (item.value === '') {
                item.classList.add('empty');
                $submitBtn.setAttribute('disabled', 'disabled');
            } else {
                item.classList.remove('empty');
                checkAllInput();
            }
        });
    });

    $stations.forEach(item => {
        item.addEventListener('change', () => {
            checkAllInput();
        });
    });



    $submitBtn.addEventListener('click', () => {
        $submitBtn.setAttribute('disabled', 'disabled');
        $submitBtn.classList.add('loading');
        const info = {};
        for (const ele of document.querySelector('#formGroup').elements) {
            info[ele.name] = ele.value;
        }
        const xhr = new XMLHttpRequest();
        xhr.open('post', '/Service/InfoMgeSvr.assx/AddUpdateInfo');

        xhr.onreadystatechange = (evt) => {
            if (evt.target.readyState === 4) {
                $submitBtn.removeAttribute('disabled');
                $submitBtn.classList.remove('loading');
                alert('提交成功');
            }
        };
        xhr.send('token=&info=' + JSON.stringify(info));
    });

    function checkAllInput() {
        for (let i = 0; i < $inputs.length; i++) {
            const item = $inputs.item(i);
            if (item.value === '') {
                $submitBtn.setAttribute('disabled', 'disabled');
                return;
            }
        }
        for (let i = 0; i < $stations.length; i++) {
            const item = $stations.item(i);
            if (item.checked) {
                $submitBtn.removeAttribute('disabled');
                break;
            } else {
                $submitBtn.setAttribute('disabled', 'disabled');
            }
        }

    }
}());