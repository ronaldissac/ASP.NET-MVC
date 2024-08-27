$(document).ready(function () {
    $('a.nav-link').click(function (event) {
        event.preventDefault();

        const href = $(this).attr('href');
        setIframeSrc(href);
    });

    function setIframeSrc(src) {
        const $iframe = $('.iFrameST');
        if ($iframe.length) {
            $iframe.attr('src', src);
        } else {
            console.error('Iframe not found');
        }
    }
});
