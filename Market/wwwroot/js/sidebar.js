
    var detailUrl = "@Url.Action('Details','Account')";
    var editUrl = "@Url.Action('Edit','Account')";
var content = ".sidebar-content";


function detailsLinkClick() {
    $("#details-link").click(function (e) {
        e.preventDefault();
        $.ajax({
            type: "GET",
            url: detailUrl,
            success: function (result) {
                $(content).html(result);
            }
        })
    })
}
  
function editLinkClick() {
    $("#edit-link").click(function (e) {
        e.preventDefault();
        $.ajax({
            type: "GET",
            url: editUrl,
            success: function (result) {
                $(content).html(result);
            }
        })
    })
}

  

