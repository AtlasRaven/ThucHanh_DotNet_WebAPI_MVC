$(function () {
    "use strict";

    $("#docDuLieuJquery").on("click", function () {
        const tenThietBi = $("#tenThietBiJquery").val().trim();
        $("#ketQuaJquery").text(tenThietBi
            ? `Tên thiết bị vừa nhập: ${tenThietBi}`
            : "Vui lòng nhập tên thiết bị.");
    });

    $("#doiNoiDungJquery").on("click", function () {
        $("#tenThietBiJquery").val("Loa kiểm âm Yamaha HS5");
        $("#ketQuaJquery")
            .text("Đã đổi nội dung bằng jQuery.")
            .css({ fontSize: "1.1rem", fontWeight: "600", color: "#0d6efd" });
    });

    $("#toggleChiTietJquery").on("click", function () {
        $("#chiTietJquery").toggle();
        $(this).text($("#chiTietJquery").is(":visible") ? "Ẩn" : "Hiện");
    });

    $("#tuKhoaDanhSach").on("keyup", function () {
        const tuKhoa = $(this).val().trim().toLocaleLowerCase("vi");
        let soKetQua = 0;

        $("#danhSachThietBiTinh li").each(function () {
            const khopTuKhoa = $(this).text().toLocaleLowerCase("vi").includes(tuKhoa);
            $(this).toggle(khopTuKhoa);
            if (khopTuKhoa) {
                soKetQua += 1;
            }
        });

        $("#soKetQuaDanhSach").text(`Tìm thấy ${soKetQua} thiết bị.`);
    }).trigger("keyup");

    $("#tuKhoaKeyup").on("keyup", function () {
        const tuKhoa = $(this).val().trim();
        $("#thongBaoKeyup").text(tuKhoa
            ? `Bạn đang nhập: ${tuKhoa}`
            : "Vui lòng nhập từ khóa");
    });

    $("#formThietBiJquery").on("submit", function (event) {
        event.preventDefault();

        const ten = $("#tenFormJquery").val().trim();
        const gia = Number($("#giaFormJquery").val());
        const soLuong = Number($("#soLuongFormJquery").val());
        const loai = $("#loaiFormJquery").val();
        const loi = [];

        const tenHopLe = ten.length > 0;
        const giaHopLe = Number.isFinite(gia) && gia > 0;
        const soLuongHopLe = Number.isInteger(soLuong) && soLuong > 0;
        const loaiHopLe = Boolean(loai);

        $("#tenFormJquery").toggleClass("is-invalid", !tenHopLe);
        $("#giaFormJquery").toggleClass("is-invalid", !giaHopLe);
        $("#soLuongFormJquery").toggleClass("is-invalid", !soLuongHopLe);
        $("#loaiFormJquery").toggleClass("is-invalid", !loaiHopLe);

        if (!tenHopLe) {
            loi.push("Tên thiết bị không được để trống.");
        }
        if (!giaHopLe) {
            loi.push("Đơn giá phải lớn hơn 0.");
        }
        if (!soLuongHopLe) {
            loi.push("Số lượng phải là số nguyên lớn hơn 0.");
        }
        if (!loaiHopLe) {
            loi.push("Vui lòng chọn loại thiết bị.");
        }

        const loiForm = $("#loiFormJquery");
        const thongBaoThanhCong = $("#thanhCongFormJquery");
        thongBaoThanhCong.addClass("d-none").text("");

        if (loi.length > 0) {
            loiForm.removeClass("d-none").text(loi.join(" "));
            return;
        }

        loiForm.addClass("d-none").text("");
        thongBaoThanhCong
            .removeClass("d-none")
            .text(`Thông tin hợp lệ: ${ten}, số lượng ${soLuong}.`);
    });
});
