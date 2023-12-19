document.addEventListener("DOMContentLoaded", function () {
    const toggleId = 'header-toggle';
    const navId = 'nav-bar';
    const bodyId = 'body-pd';
    const headerId = 'header';

    const toggle = document.getElementById(toggleId);
    const nav = document.getElementById(navId);
    const bodypd = document.getElementById(bodyId);
    const headerpd = document.getElementById(headerId);

    if (toggle && nav && bodypd && headerpd) {
        // Açık durumda başlat
        nav.classList.add('show');
        toggle.classList.add('bx-x');
        bodypd.classList.add('body-pd');
        headerpd.classList.add('body-pd');

        toggle.addEventListener('click', () => {
            // show/hide navbar
            nav.classList.toggle('show');
            // change icon
            toggle.classList.toggle('bx-x');
            // add/remove padding to body
            bodypd.classList.toggle('body-pd');
            // add/remove padding to header
            headerpd.classList.toggle('body-pd');
        });
    }

    /*===== LINK ACTIVE =====*/
    const linkColor = document.querySelectorAll('.nav_link');

    function colorLink() {
        if (linkColor) {
            linkColor.forEach(l => l.classList.remove('active'));
            this.classList.add('active');
        }
    }

    linkColor.forEach(l => l.addEventListener('click', colorLink));

    // Your code to run since DOM is loaded and ready
});
