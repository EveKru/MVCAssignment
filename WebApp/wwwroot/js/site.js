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


