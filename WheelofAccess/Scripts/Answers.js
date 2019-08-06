
$("#startReview").on("click", function () {
    $("div[id^='myModal']").first().modal('show');
})

$("div[id^='myModal']").each(function () {
    let currentModal = $(this);
    //click next
    currentModal.find('.btn-next').click(function () {
        currentModal.modal('hide');
        currentModal.closest("div[id^='myModal']").nextAll("div[id^='myModal']").first().modal('show');
    });
    //click previous
    currentModal.find('.btn-prev').click(function () {
        currentModal.modal('hide');
        currentModal.closest("div[id^='myModal']").prevAll("div[id^='myModal']").first().modal('show');
    });

});

        const radios = document.querySelectorAll('input[type="radio"]');
        for (let r of radios) {
            r.onclick = e => {
                $.ajax({
                    method: "DELETE",
                    url: "/Rest/Answer",
                    data: {
                        ReviewId: document.getElementById('Id').value,
                        QuestionId: e.target.name
                    },
                    success: (response) => {
                        console.log("success-deleted");
                    }
                });
                $.ajax({
                    method: "PUT",
                    async:false,
                    url: "/Rest/Answer",
                    data: {
                        Review_Id: document.getElementById('Id').value,
                        Option_ID: e.target.value
                    },
                    success: function (response) {
                        console.log("success");
                    }
                })
                $.ajax({
                    method: "POST",
                    url: "/Rest/UpdateRating",
                    data: {
                        id: document.getElementById('Id').value,
                    },
                    success: function (response) {
                    console.log("success")
                    }
                })
            }
        }
        