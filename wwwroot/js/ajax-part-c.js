$(function () {
    "use strict";

    const endpoints = $("#ajaxEndpoints");
    const xinChaoUrl = endpoints.data("xin-chao-url");
    const tuKhoaUrl = endpoints.data("tu-khoa-url");
    const timKiemUrl = endpoints.data("tim-kiem-url");
    let yeuCauTimKiem = null;
    let boHenGioTimKiem = null;

    $("#goiXinChao").on("click", function () {
        const ketQua = $("#ketQuaXinChao");
        ketQua.removeClass("d-none alert-danger").addClass("alert-info").text("Đang tải...");

        $.get(xinChaoUrl)
            .done(function (phanHoi) {
                ketQua.text(phanHoi);
            })
            .fail(function () {
                ketQua.removeClass("alert-info").addClass("alert-danger")
                    .text("Không thể gọi action XinChao. Vui lòng thử lại.");
            });
    });

    $("#guiTuKhoaController").on("click", function () {
        const ketQua = $("#ketQuaTuKhoaController");
        ketQua.text("Đang gửi...");

        $.get(tuKhoaUrl, { keyword: $("#tuKhoaController").val() })
            .done(function (phanHoi) {
                ketQua.text(phanHoi.message);
            })
            .fail(function () {
                ketQua.text("Không thể gửi từ khóa đến Server. Vui lòng thử lại.");
            });
    });

    const timKiemThietBi = function () {
        if (yeuCauTimKiem) {
            yeuCauTimKiem.abort();
        }

        $("#trangThaiTimKiemAjax").text("Đang tìm kiếm...");
        yeuCauTimKiem = $.get(timKiemUrl, {
            keyword: $("#tuKhoaThietBiAjax").val(),
            loaiThietBiId: $("#loaiThietBiAjax").val()
        })
            .done(function (html) {
                $("#ketQuaThietBiAjax").html(html);
                $("#trangThaiTimKiemAjax").text("Đã cập nhật kết quả.");
            })
            .fail(function (xhr, status) {
                if (status !== "abort") {
                    $("#trangThaiTimKiemAjax").text("Không thể tìm kiếm thiết bị. Vui lòng thử lại.");
                }
            });
    };

    $("#timKiemThietBiAjax").on("click", timKiemThietBi);

    $("#tuKhoaThietBiAjax").on("keyup", function () {
        window.clearTimeout(boHenGioTimKiem);
        boHenGioTimKiem = window.setTimeout(timKiemThietBi, 250);
    });

    $("#loaiThietBiAjax").on("change", timKiemThietBi);
});
