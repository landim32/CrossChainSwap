const API_URL = "https://localhost:44374";

function doError(msg) {
    $("#errorBox span").text(msg);
    $("#errorBox").show();
    //$("#openModalBtn").prop("disabled", true);
}

function loadPrice() {
    $.getJSON( API_URL + "/api/CoinMarketCap/getcurrentprice", function( data ) {
        //alert(JSON.stringify(data));
        $("p.description").data("bitcoin", data.btcToStxText);
        $("p.description").data("stacks", data.stxToBtcText);
        $("#BtcProportion").val(data.btcProportion);
        $("#StxProportion").val(data.stxProportion);
        let priceBtc = parseFloat(data.original.price).toLocaleString('en-US', {
            style: 'currency',
            currency: 'USD',
        });
        let priceStx = parseFloat(data.destiny.price).toLocaleString('en-US', {
            style: 'currency',
            currency: 'USD',
        });
        $("p.description").data("btcPrice", priceBtc);
        $("p.description").data("stxPrice", priceStx);
        if ($("#title").data("coin") == "bitcoin") {
            $("p.description").text($("p.description").data("bitcoin"));
            $("#origPrice").text($("p.description").data("btcPrice"));
            $("#destPrice").text($("p.description").data("stxPrice"));
        }
        else {
            $("p.description").text($("p.description").data("stacks"));
            $("#origPrice").text($("p.description").data("stxPrice"));
            $("#destPrice").text($("p.description").data("btcPrice"));
        }

        $("#openModalBtn").prop("disabled", false);
    }).fail(function() {
        doError("Cannot get coins price from CoinMarketCap.");
    });
}

function registerUser(btcAddr, stxAddr) {
    $("#BtcAddress").val(btcAddr);
    $("#StxAddress").val(stxAddr);

    let apiUrl = API_URL + "/api/Auth/checkUserRegister/" + btcAddr + "/" + stxAddr;
    $.getJSON( apiUrl, function( data ) {
        alert(JSON.stringify(data));
        let userAddr = btcAddr.substr(0, 6) + '...' + btcAddr.substr(-4);
        $("#userName").text(userAddr);
        $("#navbarUser").show();
        $("#connectBtn").hide();
    }).fail(function() {
        doError("Cannot registrer user.");
        $("#openModalBtn").prop("disabled", true);
    });
}

function loadPoolInfo() {
    $.getJSON( API_URL + "/api/Pool/getpoolinfo", function( data ) {
        //alert(JSON.stringify(data));
        //alert(data.btcAddress);
        $("#PoolBtcAddress").val(data.btcAddress);
        let poolBalance = parseInt(data.btcBalance) / 100000000;
        $("#poolBalance").text("Pool Balance " + poolBalance + " BTC");
        loadPrice();
    
        //$("#openModalBtn").prop("disabled", false);
    }).fail(function() {
        doError("Cannot get pool information.");
        $("#openModalBtn").prop("disabled", true);
    });
}

function loadAllSwaps() {
    $("#mainContainer").load("./list.html", function () {

        //$("#tableTx > tbody").empty();        

        $.getJSON( API_URL + "/api/Transaction/listalltransactions", function( data ) {
            //alert(JSON.stringify(data));
            $("#tableTx > tbody").empty();
            data.forEach(function(item) {
                let userAddr = ((item.inttype == 1) ? item.btcaddress : item.stxaddress);
                let userView = userAddr.substr(0, 6) + '...' + userAddr.substr(-4);
                let rowStr = 
                    "<tr>\n" +
                    "<td><a class=\"txBtn\" href=\"#modalTx\" data-txid=\"" + item.txid + "\">" + item.txtype + "</a></td>\n" +
                    "<td><a class=\"txBtn\" href=\"#modalTx\" data-txid=\"" + item.txid + "\">" + userView + "</a></td>\n" +
                    "<td><a class=\"txBtn\" href=\"#modalTx\" data-txid=\"" + item.txid + "\">" + item.updateat + "</a></td>\n" +
                    "<td><a class=\"txBtn\" href=\"#modalTx\" data-txid=\"" + item.txid + "\">" + 
                        ((item.inttype == 1) ? item.btcamount : item.stxamount) +
                        " -> " +
                        ((item.inttype == 1) ? item.stxamount : item.btcamount) + 
                    "</a></td>\n" +
                    "<td><a class=\"txBtn\" href=\"#modalTx\" data-txid=\"" + item.txid + "\">" + item.status + "</a></td>\n" +
                    "</tr>";
                $('#tableTx > tbody:last-child').append(rowStr);
            });
            $('.txBtn').on("click", function (e) {
                e.preventDefault();

                $("#txModal").modal("show");

                let txId = $(this).data("txid");

                $.getJSON( API_URL + "/api/Transaction/gettransaction/" + txId, function( data ) {
                    //alert(JSON.stringify(data));
                    $("#txTransactionTitle").text("Transaction " + data.txtype + " #" + data.txid);
                    $("#txStatus").text(data.status);
                    if (data.inttype == 1) {
                        $("#txOrigAddressLabel").text("BTC Address");
                        $("#txOrigAddress").attr("href", data.btcaddressurl);
                        $("#txOrigAddress").text(data.btcaddress);
                        $("#txOrigTxIdLabel").text("BTC TxID");
                        $("#txOrigTxId").attr("href", data.btctxidurl);
                        $("#txOrigTxId").text(data.btctxid);

                        $("#txDestAddressLabel").text("STX Address");
                        $("#txDestAddress").attr("href", data.stxaddressurl);
                        $("#txDestAddress").text(data.stxaddress);
                        $("#txDestTxIdLabel").text("STX TxID");
                        $("#txDestTxId").attr("href", data.stxtxidurl);
                        $("#txDestTxId").text(data.stxtxid);

                        $("#txAmout").text(data.btcamount + " -> " + data.stxamount);
                        $("#txFee").text(data.btcfee + ", " + data.stxfee);
                    }
                    else {
                        $("#txOrigAddressLabel").text("STX Address");
                        $("#txOrigAddress").attr("href", data.stxaddressurl);
                        $("#txOrigAddress").text(data.stxaddress);
                        $("#txOrigTxIdLabel").text("STX TxID");
                        $("#txOrigTxId").attr("href", data.stxtxidurl);
                        $("#txOrigTxId").text(data.stxtxid);

                        $("#txDestAddressLabel").text("BTC Address");
                        $("#txDestAddress").attr("href", data.btcaddressurl);
                        $("#txDestAddress").text(data.btcaddress);
                        $("#txDestTxIdLabel").text("BTC TxID");
                        $("#txDestTxId").attr("href", data.btctxidurl);
                        $("#txDestTxId").text(data.btctxid);

                        $("#txAmout").text(data.stxamount + " -> " + data.btcamount);
                        $("#txFee").text(data.stxfee + ", " + data.btcfee);
                    }
                    $("#txDate").text("Create at " + data.createat + ", latest udpate at " + data.updateat);
                }).fail(function() {
                    doError("Cannot get transactions informations.");
                    $("#openModalBtn").prop("disabled", true);
                });

                return false;
            })
        }).fail(function() {
            doError("Cannot get transactions informations.");
            $("#openModalBtn").prop("disabled", true);
        });
    });
}

function loadSwapForm() {
    $("#mainContainer").load("./swap.html", function () {
        $("#alertClose").on("click", function (e) {
            e.preventDefault();
            $("#errorBox").hide();
        });

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
    
                $("#origPrice").text($("p.description").data("stxPrice"));
                $("#destPrice").text($("p.description").data("btcPrice"));
    
                $("#title").data("coin", "stacks");
            }
            else {
                $("#origSelected").val("bitcoin");
                $("#destSelected").val("stacks");
                $("#title").text("BTC To STX");
                $("p.description").text($("p.description").data("bitcoin"));
    
                $("#origPrice").text($("p.description").data("btcPrice"));
                $("#destPrice").text($("p.description").data("stxPrice"));
    
                $("#title").data("coin", "bitcoin");
            }
        });

        $("#origSelected").on("change", function (e) {
            $("#title").data("coin", ($(this).val() == "bitcoin") ? "stacks" : "bitcoin");
            $("#changeBtn").trigger("click");
        });

        $("#destSelected").on("change", function (e) {
            $("#title").data("coin", ($(this).val() == "bitcoin") ? "bitcoin" : "stacks");
            $("#changeBtn").trigger("click");
        });

        $("#openModalBtn").on("click", function (e) {
            e.preventDefault();
    
            let vOrigAmout = parseFloat($("#origAmount").val());
    
            if (vOrigAmout > 0) {
    
                vOrigAmout = Math.round(vOrigAmout * 100000) / 100000;
                $(".modalOrigCoin").text(vOrigAmout + " BTC");
    
                let vDestAmout = parseFloat($("#destAmount").val());
                vDestAmout = Math.round(vDestAmout * 100000) / 100000;
                $(".modalDestCoin").text($("#destAmount").val() + " STX");
    
                $(".modalOrigAddr").text($("#PoolBtcAddress").val());
                $(".modalDestAddr").text($("#stxAddress").val());
    
                $("#swapModal").modal("show");
            }
            else {
                doError("Amount cant be empty.");
            }
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
    
                    let vOrigAmout = parseFloat($("#origAmount").val()) * 100000000;
                    let vDestAmout = parseFloat($("#destAmount").val()) * 100000000;
    
                    let txParam = {
                        btcToStx: true,
                        btcAddress: $("#BtcAddress").val(),
                        stxAddress: $("#StxAddress").val(),
                        btcTxid: response.result.txid,
                        stxTxid: null,
                        btcAmount: vOrigAmout,
                        stxAmount: vDestAmout
                    };
                    $.ajax({
                        url: API_URL + "/api/Transaction/createTx",
                        type: "PUT",
                        data: JSON.stringify(txParam),
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function(response) {
                            alert(JSON.stringify(response));
                            console.log(response);
                        },
                        error: function(xhr, status, error) {
                            doError(xhr.responseText);
                            $("#openModalBtn").prop("disabled", true);
                        }
                    });
                    //$("#btcAddress").val()
                });
              
                //console.log("Response:", response);
                //console.log("Transaction ID:", response.result.txid);
              } catch (error) {
                doError("Request error: " + error.error.message + "(" + error.error.code + ")");
              }
        });

        loadPoolInfo();
    });
}

(function(){

    /*
    $.ajaxSetup({
        headers : {   
          'Authorization' : 'Basic ' + 
        }
      });
      */

    /*
    function accountFromDerivationPath(path) {
        console.log(path);
        const segments = path.split("/");
        const account = parseInt(segments[3].replaceAll("'", ""), 10);
        if (isNaN(account)) throw new Error("Cannot parse account number from path");
        return account;
    }
    */

    $("#connectBtn").on("click", function (e) {
        e.preventDefault();

        if (!window.LeatherProvider) {
            alert("LeatherProvider not found. Install the Leather extension from leather.io/install.");
            return;
        }

        window.LeatherProvider?.request("getAddresses").then(function (response) {

            let addr = response.result.addresses.find(addr => addr.type == "p2wpkh");
            let addrStx = response.result.addresses.find(addr => addr.symbol == "STX");
            registerUser(addr.address, addrStx.address);
        });

    });
    $("#disconnectBtn").on("click", function (e) {
        e.preventDefault();

        $("#navbarUser").hide();
        $("#connectBtn").show();
        $("#userName").text("Anonymous");
    });

    $("#openModalBtn").prop("disabled", false);

    $("#linkHome").on("click", function (e) {
        e.preventDefault();

        $(".av-link").removeClass("active");
        $(this).addClass("active");

        loadSwapForm();
    });
    $("#linkMySwaps").on("click", function (e) {
        e.preventDefault();

        $(".av-link").removeClass("active");
        $(this).addClass("active");

        loadAllSwaps();
    });
    $("#linkAllSwaps").on("click", function (e) {
        e.preventDefault();

        $(".av-link").removeClass("active");
        $(this).addClass("active");

        loadAllSwaps();
    });

    //loadPrice();
    loadSwapForm();
      

 })(jQuery)