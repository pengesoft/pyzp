(function () {
    const $inputs = document.querySelectorAll('.js-input');
    const $stations = document.querySelectorAll('.js-station');
    const $otherCheckbox = document.querySelector('#other-checkbox');
    const $otherInput = document.querySelector('#other-input');
    const $submitBtn = document.querySelector('#submit');


    $inputs.forEach(item => {
        item.addEventListener('input', () => {
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

    $otherCheckbox.addEventListener('click', () => {
        if ($otherCheckbox.checked) {
            $otherInput.removeAttribute('disabled');
            $otherInput.focus();
        } else {
            $otherInput.setAttribute('disabled', ' disabled');
            $otherInput.value = '';
        }
    });

    $otherInput.addEventListener('click', (evt) => {
        evt.stopPropagation();
        evt.preventDefault();
    });

    $submitBtn.addEventListener('click', () => {
        $submitBtn.setAttribute('disabled', 'disabled');
        $submitBtn.classList.add('loading');
        const info = {};
        for (const ele of document.querySelector('#formGroup').elements) {
            info[ele.name] = ele.value;
        }
        const checkboxs = document.querySelectorAll('input[name="Station"]');
        const stations = [];
        checkboxs.forEach(item => {
            if (item.checked) {
                if (item.value === 'other') {
                    stations.push($otherInput.value);
                } else {
                    stations.push(item.value);
                }
            }
        });
        info.Station = stations.join(' | ');

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