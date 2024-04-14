const toggleMenu = () => {
    const menu = document.getElementById('menu');
    const accountButtons = document.getElementById('account-buttons');
    const isMenuVisible = !menu.classList.contains('hide');

    menu.classList.toggle('hide');
    accountButtons.classList.toggle('hide');
    menu.classList.toggle('visible', isMenuVisible);
    accountButtons.classList.toggle('visible', isMenuVisible);

    if (isMenuVisible) {
        disableScroll();
    }
    else {
        enableScroll();
    }

    const btnMobile = document.querySelector('.btn-mobile');
    btnMobile.classList.toggle('active', isMenuVisible);
}

const disableScroll = () => {
    document.body.style.overflow = 'hidden';
}

const enableScroll = () => {
    document.body.style.overflow = 'auto';
}

const checkScreenSize = () => {
    const menu = document.getElementById('menu');
    const accountButtons = document.getElementById('account-buttons');

    if (window.innerWidth >= 990) {
        menu.classList.remove('hide');
        accountButtons.classList.remove('hide');
        menu.classList.remove('visible');
        accountButtons.classList.remove('visible');
        enableScroll();
    }
    else {
        if (!menu.classList.contains('hide')) {
            menu.classList.add('hide');
        }
        if (!accountButtons.classList.contains('hide')) {
            accountButtons.classList.add('hide');
        }
    }
};

window.addEventListener('resize', checkScreenSize);
checkScreenSize();

// Help from ChatGPT heheh
// Store the current scroll position before form submission
window.onload = function () {
    var scrollY = localStorage.getItem("scrollY");
    console.log("Stored scroll position:", scrollY);
    if (scrollY !== null) {
        setTimeout(function () {
            window.scrollTo(0, scrollY); // Scroll to the stored position
        }, 0);
        localStorage.removeItem("scrollY"); // Clear the stored position
        console.log("Restored scroll position:", scrollY);
    }
};

// Attach event listener to form submission
document.addEventListener('submit', function (event) {
    // Get the current scroll position
    var currentScrollY = window.scrollY;
    console.log("Current scroll position:", currentScrollY);

    // Store the scroll position before the form is submitted
    localStorage.setItem("scrollY", currentScrollY);
});

// primarly used for the change of the profileimage
document.addEventListener('DOMContentLoaded', function () {
    handleProfileImageUpload()
})
function handleProfileImageUpload() {
    let uploader = document.querySelector('#fileUploader')
    if (uploader != undefined) {
        uploader.addEventListener('change', function () {
            if (this.files.length > 0)
                this.form.submit()
        })
    }
}

// courses category dropdown
document.addEventListener('DOMContentLoaded', function () {
    select();
    searchQuery();
});

function select() {
    let select = document.querySelector('.select');
    let selected = select.querySelector('.selected');
    let selectOptions = select.querySelector('.select-options');

    // Toggle the display of selectOptions when clicking on selected
    selected.addEventListener('click', function () {
        if (selectOptions.style.display === 'block') {
            selectOptions.style.display = 'none';
        } else {
            selectOptions.style.display = 'block';
        }
    });

    // Update selected option and close selectOptions when clicking an option
    let options = selectOptions.querySelectorAll('.option');
    options.forEach(function (option) {
        option.addEventListener('click', function () {
            selected.innerHTML = this.textContent;
            selectOptions.style.display = 'none';
            let category = this.getAttribute('data-value');
            selected.setAttribute('data-value', category);
            updateCourseByFilter();
        });
    });
}

function searchQuery() {
    document.querySelector('#searchQuery').addEventListener('keyup', function () {
        updateCourseByFilter();
    });
}

function updateCourseByFilter() {
    const category = document.querySelector('.select .selected').getAttribute('data-value') || 'all';
    const searchQuery = document.querySelector('#searchQuery').value;
    const url = `/courses/index?category=${encodeURIComponent(category)}&searchQuery=${encodeURIComponent(searchQuery)}`;

    fetch(url)
        .then(res => res.text())
        .then(data => {
            const parser = new DOMParser();
            const dom = parser.parseFromString(data, 'text/html');
            document.querySelector('.items').innerHTML = dom.querySelector('.items').innerHTML;
        });
}













