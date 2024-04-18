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
                // Tablodaki tüm satýrlarý gizle
                $(".table tbody tr").hide();

                // UpdateStatus deðeri false olan satýrlarý göster
                $(".table tbody tr:has(td:nth-child(3) span.btn-danger)").show();
            } else {
                // Tüm satýrlarý göster
                $(".table tbody tr").show();
            }

            // Durumu tersine çevir
            pasifUrunlerGoster = !pasifUrunlerGoster;
        });
    });


