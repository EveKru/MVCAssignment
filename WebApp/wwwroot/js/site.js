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




