function doError(msg) {
    $("#errorBox span").text(msg);
    $("#errorBox").show();
    $("#openModalBtn").prop("disabled", true);
}

function loadPrice() {
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

        $("#openModalBtn").prop("disabled", false);
    }).fail(function() {
        doError("Cannot get coins price from CoinMarketCap.");
    });
}

function loadPoolInfo() {
    $.getJSON( "https://localhost:44374/api/Pool/getpoolinfo", function( data ) {
        //alert(JSON.stringify(data));
        //alert(data.btcAddress);
        $("#PoolBtcAddress").val(data.btcAddress);

        loadPrice();
    
        //$("#openModalBtn").prop("disabled", false);
    }).fail(function() {
        doError("Cannot get pool information.");
    });
}

(function(){

    /*
    function accountFromDerivationPath(path) {
        console.log(path);
        const segments = path.split("/");
        const account = parseInt(segments[3].replaceAll("'", ""), 10);
        if (isNaN(account)) throw new Error("Cannot parse account number from path");
        return account;
    }
    */

    $("#openModalBtn").prop("disabled", false);

    $('input.numericInput').inputNumberFormat({
        'decimal': 5,
        'decimalAuto': 5,
        'separator': '.',
        'separatorAuthorized': ['.'], //['.', ','],
        allowNegative: false
      });
      $('input.numericInput').on("input", function (e) {
        let amount = parseFloat($("#origAmount").val());
        let btcP = parseFloat($("#BtcProportion").val());
        let stxP = parseFloat($("#StxProportion").val());
        if ($("#title").data("coin") == "bitcoin") {
            let price = btcP * amount;
            $("#destAmount").val(price.toFixed(5));
        }
        else {
            let price = stxP * amount;
            $("#destAmount").val(price.toFixed(5));
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

        if (!window.LeatherProvider) {
            alert("LeatherProvider not found. Install the Leather extension from leather.io/install.");
            return;
        }

        window.LeatherProvider?.request("getAddresses").then(function (response) {

            let addr = response.result.addresses.find(addr => addr.type == "p2wpkh");
            $("#BtcAddress").val(addr.address);
            let addrStx = response.result.addresses.find(addr => addr.symbol == "STX");
            $("#StxAddress").val(addrStx.address);
            let userAddr = addr.address.substr(0, 6) + '...' + addr.address.substr(-4);
            $("#userName").text(userAddr);
            $("#navbarUser").show();
            $("#connectBtn").hide();
        });

    });
    $("#disconnectBtn").on("click", function (e) {
        e.preventDefault();

        $("#navbarUser").hide();
        $("#connectBtn").show();
        $("#userName").text("Anonymous");
    });
    $("#openModalBtn").on("click", function (e) {
        e.preventDefault();

        let vOrigAmout = parseFloat($("#origAmount").val());
        vOrigAmout = Math.round(vOrigAmout * 100000) / 100000;
        $(".modalOrigCoin").text(vOrigAmout + " BTC");

        let vDestAmout = parseFloat($("#destAmount").val());
        vDestAmout = Math.round(vDestAmout * 100000) / 100000;
        $(".modalDestCoin").text($("#destAmount").val() + " STX");

        $(".modalOrigAddr").text($("#PoolBtcAddress").val());
        $(".modalDestAddr").text($("#stxAddress").val());

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
    $("#confirmBtn").on("click", function (e) {
        e.preventDefault();

        let amountOrig = parseFloat($("#origAmount").val()) * 100000000;

        try {
            window.LeatherProvider.request("sendTransfer", {
              recipients: [
                {
                  address: $("#PoolBtcAddress").val(),
                  amount: amountOrig,
                }
              ],
              network: "testnet",
            }).then(function (response) {
                alert(response.result.txid);
                console.log("Transaction ID:", response.result.txid);
                //$("#btcAddress").val()
            });
          
            //console.log("Response:", response);
            //console.log("Transaction ID:", response.result.txid);
          } catch (error) {
            doError("Request error: " + error.error.message + "(" + error.error.code + ")");
          }
    });

    //loadPrice();
    loadPoolInfo();
      

 })(jQuery)