const toggleMenu = () => {
    document.getElementById('menu').classList.toggle('hide');
    document.getElementById('account-buttons').classList.toggle('hide');

    const isMenuVisible = !document.getElementById('menu').classList.contains('hide');
    document.getElementById('menu').classList.toggle('visible', isMenuVisible);
    document.getElementById('account-buttons').classList.toggle('visible', isMenuVisible);
}

const checkScreenSize = () => {

    if (window.innerWidth >= 990) {
        document.getElementById('menu').classList.remove('hide');
        document.getElementById('account-buttons').classList.remove('hide');
        document.getElementById('menu').classList.remove('visible');
        document.getElementById('account-buttons').classList.remove('visible');
    }
    else {
        if (!document.getElementById('menu').classList.contains('hide')) {
            document.getElementById('menu').classList.add('hide');
        }
        if (!document.getElementById('account-buttons').classList.contains('hide')) {
            document.getElementById('account-buttons').classList.add('hide');
        }
    }
};

window.addEventListener('resize', checkScreenSize);
checkScreenSize();









