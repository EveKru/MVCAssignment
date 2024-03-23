
const formErrorHandler = (element, validationResult) => {
    let spanElement = document.querySelector(`[data-valmsg-for="${element.name}"]`)

    if (validationResult) {
        element.classList.remove('input-validation-error')
        spanElement.classList.remove('field-validation-error')
        spanElement.classList.add('field-validation-valid')
        spanElement.innerHTML = ''
    }
    else {
        element.classList.add('input-validation-error')
        spanElement.classList.add('field-validation-error')
        spanElement.classList.remove('field-validation-valid')
        spanElement.innerHTML = element.dataset.valRequired
    }
}

const lenghtValidator = (value, minlenght = 2) => {
    if (value.length >= minlenght)
        return true

    return false
}

const compareValidator = (value, compareValue) => {
    if (value === compareValue)
        return true

    return false
}

const checkedValidator = (element) => {
    if (element.checked)
        return true

    return false
}

const textValidator = (element) => {
    formErrorHandler(element, lenghtValidator(element.value))
}

const emailValidator = (element) => {
    const regEx = /^(([^<>()[\]\.,;:\s@\"]+(\.[^<>()[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/
    formErrorHandler(element, regEx.test(element.value))
}

const passwordValidator = (element) => {
    if (element.dataset.valEqualtoOther !== undefined) {
        formErrorHandler(element, compareValidator(element.value, document.getElementsByName(element.dataset.valEqualtoOther.replace('*.', ''))[0].value));
    }
    else {
        const regEx = /^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$/;
        formErrorHandler(element, regEx.test(element.value))
    }
};

const checkboxValidator = (element) => {
    formErrorHandler(element, checkedValidator(element))
}

let forms = document.querySelectorAll('form')
let inputs = forms[0].querySelectorAll('input')

inputs.forEach(input => {
    if (input.dataset.val === 'true') {
        if (input.type === 'checkbox') {
            input.addEventListener('change', event => {
                checkboxValidator(event.target)
            })
        }
        else {
            input.addEventListener('keyup', (event) => {
                switch (event.target.type) {
                    case 'text':
                        textValidator(event.target)
                        break;
                    case 'email':
                        emailValidator(event.target)
                        break;
                    case 'password':
                        passwordValidator(event.target)
                        break;
                }
            })
        }
    }
})