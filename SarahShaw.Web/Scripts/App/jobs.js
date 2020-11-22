$(function () {
    $('.btnMarkComplete').click(function () {
        var jobId = $(this).data('jobid');
        MarkJobAsComplete(jobId);
    });
});

function MarkJobAsComplete(jobId) {
    var confirmMarkComplete = confirm("Are you sure you want to mark this job complete?");
    if (confirmMarkComplete) {
        $("#overlay").show();
        $.ajax({
            type: "post",
            url: "/api/jobs/markcomplete?jobId=" + jobId,
            success: function (result) {
                if (result === "success") {
                    //change the status text in table
                    $('#status-' + jobId).text('Complete');
                    //remove existing status class
                    $('#trJob-' + jobId).removeAttr('class');
                    //add complete class
                    $('#trJob-' + jobId).addClass('status-complete');

                    $('#btnMarkComplete-' + jobId).remove();
                }
                $("#overlay").hide();
            }
        });
    }
}
