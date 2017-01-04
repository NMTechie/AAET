(function () {

    $(document).ready(function () {
        $('#resultSearchGrid').DataTable(
        {
            "serverSide": true,
            "processing": true,
            "deferRender": true,
            "sDom": '<"top"l>rt<"bottom"ip><"clear">',
            "lengthMenu": [[10, 20, 50, 100, -1], [10, 20, 50, 100, "All"]],
            "language": {
                "info": "Showing page _PAGE_ of _PAGES_",
                "infoEmpty": "No records found for this filter criteria",
                "infoFiltered": ""
            },
            "order": [[0, 'asc']],
            "rowId": 'MessageId',
            "ajax": {
                "url": '/ConfigurationUIGridBehaviour',
                "data": function (d) {
                    return $.extend({}, d, {
                        "searchMessageId": $('#txtMessageId').val(),
                        "searchMessageBody": $('#txtMessageBody').val(),
                        "searchMessageReceiveTime": $('#txtMessageReceiveTime').val(),
                        "searchStudentName": $('#txtStudentName').val()
                    });
                },
                "dataSrc": 'ResultSet'
            },
            "sPaginationType": 'full_numbers',
            "columnDefs": [
                     { title: 'Message Id', targets: 0, data: 'MessageId', name: "MessageId" },
                     { title: 'Student Name', targets: 1, data: 'StudentName', name: "StudentName" },
                     { title: 'Message Body', targets: 2, data: 'MessageBody', name: "MessageBody" },
                     { title: 'Message ReceiveTime', targets: 3, data: 'MessageReceiveTime', name: "MessageReceiveTime" }                     
            ]
        }
        );
    });

    btnSearch_Click = function () {
        filterSearchColumn();
    };

    btnClearSearch_Click = function () {
        clearSearchParams();
        filterSearchColumn();
    };

    function filterSearchColumn() {
        $('#resultSearchGrid').DataTable().draw();
    };

    function clearSearchParams() {
        $('#txtMessageId,#txtStudentName,#txtMessageBody,#txtMessageReceiveTime').ClearText();
    };

}(jQuery));

