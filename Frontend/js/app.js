(function(){

    function doError(msg) {
        $("#errorBox span").text(msg);
        $("#errorBox").show();
        //$("#connectBtn").prop("disabled", true);
    }

    /*
    if (window.LeatherProvider) {
        doError("Leather Wallet is not installed!");
    }
    */

    $("#connectBtn").prop("disabled", false);

    $('input.numericInput').inputNumberFormat({
        'decimal': 8,
        'decimalAuto': 8,
        'separator': '.',
        'separatorAuthorized': ['.', ','],
        allowNegative: false
      });
      $('input.numericInput').on("input", function (e) {
        let amount = parseFloat($("#origAmount").val());
        let btcP = parseFloat($("#BtcProportion").val());
        let stxP = parseFloat($("#StxProportion").val());
        if ($("#title").data("coin") == "bitcoin") {
            let price = btcP * amount;
            $("#destAmount").val(price.toFixed(8));
        }
        else {
            let price = stxP * amount;
            $("#destAmount").val(price.toFixed(8));
        }
      });
    $("#changeBtn").on("click", function (e) {
        e.preventDefault();

        let amount = $("#origAmount").val();
        $("#origAmount").val($("#destAmount").val());
        $("#destAmount").val(amount);

        if ($("#title").data("coin") == "bitcoin") {
            $("#origSelected").val("stacks");
            $("#destSelected").val("bitcoin");
            $("#title").text("STX To BTC");
            $("p.description").text($("p.description").data("stacks"));
            $("#title").data("coin", "stacks");
        }
        else {
            $("#origSelected").val("bitcoin");
            $("#destSelected").val("stacks");
            $("#title").text("BTC To STX");
            $("p.description").text($("p.description").data("bitcoin"));
            $("#title").data("coin", "bitcoin");
        }
    });
    $("#connectBtn").on("click", function (e) {
        e.preventDefault();

        $("#swapModal").modal("show");
    });

    $("#origSelected").on("change", function (e) {
        $("#title").data("coin", ($(this).val() == "bitcoin") ? "stacks" : "bitcoin");
        $("#changeBtn").trigger("click");
    });
    $("#destSelected").on("change", function (e) {
        $("#title").data("coin", ($(this).val() == "bitcoin") ? "bitcoin" : "stacks");
        $("#changeBtn").trigger("click");
    });
    $.getJSON( "https://localhost:44374/api/CoinMarketCap/getcurrentprice", function( data ) {
        //alert(JSON.stringify(data));
        $("p.description").data("bitcoin", data.btcToStxText);
        $("p.description").data("stacks", data.stxToBtcText);
        $("p.description").text(($("#title").data("coin") == "bitcoin") ? 
            $("p.description").data("bitcoin") : 
            $("p.description").data("stacks")
        );
        $("#BtcProportion").val(data.btcProportion);
        $("#StxProportion").val(data.stxProportion);

        $("#connectBtn").prop("disabled", false);
    }).fail(function() {
        doError("Cannot get coins price from CoinMarketCap.");
    });
 })(jQuery)