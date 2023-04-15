window.onload = function () {
    UploadChapterMonthlyReport();
}

function UploadChapterMonthlyReport() {
    $.ajax({
        url: "/Admin/Home/UploadChapterMonthlyReport",
        type: "GET",
        dataType: "json",
        beforeSend: function () { },
        context: this,
        success: function (dt) {
            console.log(dt);
            var data = {
                labels: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"],
                datasets: [{
                    label: "Tần suất cập nhật chương mới trong năm",
                    backgroundColor: "rgba(255,99,132,0.2)",
                    borderColor: "rgba(255,99,132,1)",
                    borderWidth: 2,
                    borderRadius: 5,
                    hoverBackgroundColor: "rgba(255,99,132,0.4)",
                    hoverBorderColor: "rgba(255,99,132,1)",
                    data: dt,
                }]
            };

            var options = {
                maintainAspectRatio: false,
                scales: {
                    y: {
                        stacked: true,
                        grid: {
                            display: true,
                            color: "rgba(255,99,132,0.2)"
                        }
                    },
                    x: {
                        grid: {
                            display: false
                        }
                    }
                }
            };

            new Chart('chart', {
                type: 'bar',
                options: options,
                data: data
            });

        },
        error: function () { },
        complete: function () { }
    });
}