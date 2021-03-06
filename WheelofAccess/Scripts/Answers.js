﻿
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
$.ajax({
    method: "GET",
    url: "/Rest/Answers",
    success: (response) => {
        for (let a of response) {
            for (let r of radios) {
                if (a.PossibleAnswerId == r.id && a.ReviewId == document.getElementById('Id').value) {
                    r.checked = true;
                }
            }
        }
    }
});

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
                    }
                });
                $.ajax({
                    method: "PUT",
                    async:false,
                    url: "/Rest/Answer",
                    data: {
                        ReviewId: document.getElementById('Id').value,
                        PossibleAnswerId: e.target.value
                    },
                    success: function (response) {
                    }
                })
                $.ajax({
                    method: "POST",
                    url: "/Rest/UpdateRating",
                    data: {
                        id: document.getElementById('Id').value,
                    },
                    success: function (response) {
                    }
                })
            }
        }
        