    function toggleVisibility(containerId) {
        var container = $("#" + containerId);
    container.slideToggle();
    }

    $(document).ready(function () {
        $('.toggle-row').click(function () {
            var row = $(this).closest('tr');
            var container = row.find('.remaining-barcodes');

            row.nextUntil('tr:has(.toggle-row)').slideToggle();
            container.slideToggle();

            var icon = $(this).find('i');
            icon.toggleClass('fas fa-angle-down fas fa-angle-right');
        });
        var pasifUrunlerGoster = true;

        $(".btn-primary.btn-s").on("click", function () {
            if (pasifUrunlerGoster) {
                // Tablodaki t�m sat�rlar� gizle
                $(".table tbody tr").hide();

                // UpdateStatus de�eri false olan sat�rlar� g�ster
                $(".table tbody tr:has(td:nth-child(3) span.btn-danger)").show();
            } else {
                // T�m sat�rlar� g�ster
                $(".table tbody tr").show();
            }

            // Durumu tersine �evir
            pasifUrunlerGoster = !pasifUrunlerGoster;
        });
    });


