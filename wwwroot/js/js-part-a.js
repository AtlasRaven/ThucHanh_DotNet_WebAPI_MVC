(() => {
    "use strict";

    const tenInput = document.getElementById("tenThietBiJs");
    const giaInput = document.getElementById("donGiaJs");
    const soLuongInput = document.getElementById("soLuongJs");
    const ketQua = document.getElementById("ketQuaJs");
    const vungThongTin = document.getElementById("vungThongTin");
    const toggleButton = document.getElementById("toggleThongTin");

    const docDuLieu = () => ({
        ten: tenInput.value.trim(),
        gia: Number(giaInput.value),
        soLuong: Number(soLuongInput.value)
    });

    const hienThiKetQua = (noiDung, isError = false) => {
        ketQua.textContent = noiDung;
        ketQua.classList.remove("d-none", "alert-info", "alert-danger", "alert-success");
        ketQua.classList.add(isError ? "alert-danger" : "alert-info");
    };

    document.getElementById("hienThiThietBi").addEventListener("click", () => {
        const thietBi = docDuLieu();
        if (!thietBi.ten || giaInput.value === "" || soLuongInput.value === "") {
            hienThiKetQua("Vui lòng nhập đầy đủ tên, đơn giá và số lượng.", true);
            return;
        }

        document.getElementById("tenHienThi").textContent = thietBi.ten;
        document.getElementById("giaHienThi").textContent =
            `${thietBi.gia.toLocaleString("vi-VN")} ₫`;
        document.getElementById("soLuongHienThi").textContent = String(thietBi.soLuong);
        hienThiKetQua("Đã hiển thị thông tin thiết bị.");
    });

    document.getElementById("tinhThanhTien").addEventListener("click", () => {
        const thietBi = docDuLieu();
        if (!thietBi.ten || giaInput.value === "" || soLuongInput.value === "") {
            hienThiKetQua("Vui lòng nhập đầy đủ tên, đơn giá và số lượng.", true);
            return;
        }
        if (!Number.isFinite(thietBi.gia) || !Number.isFinite(thietBi.soLuong) ||
            thietBi.gia <= 0 || thietBi.soLuong <= 0) {
            hienThiKetQua("Đơn giá và số lượng phải lớn hơn 0.", true);
            return;
        }

        const thanhTien = thietBi.gia * thietBi.soLuong;
        hienThiKetQua(`Thành tiền: ${thanhTien.toLocaleString("vi-VN")} ₫`);
    });

    document.getElementById("kiemTraSoLuong").addEventListener("click", () => {
        if (soLuongInput.value === "") {
            hienThiKetQua("Vui lòng nhập số lượng.", true);
            return;
        }

        const soLuong = Number(soLuongInput.value);
        if (!Number.isFinite(soLuong) || soLuong <= 0) {
            hienThiKetQua("Số lượng không hợp lệ", true);
        } else if (soLuong <= 10) {
            hienThiKetQua("Số lượng trong mức cho phép");
        } else {
            hienThiKetQua("Số lượng lớn");
        }
    });

    toggleButton.addEventListener("click", () => {
        const dangAn = vungThongTin.classList.toggle("d-none");
        toggleButton.textContent = dangAn ? "Hiện thông tin" : "Ẩn thông tin";
    });

    document.getElementById("xoaThietBi").addEventListener("click", () => {
        if (!window.confirm("Bạn có chắc chắn muốn xóa thông tin thiết bị đang hiển thị không?")) {
            return;
        }

        document.getElementById("tenHienThi").textContent = "Chưa có dữ liệu";
        document.getElementById("giaHienThi").textContent = "Chưa có dữ liệu";
        document.getElementById("soLuongHienThi").textContent = "Chưa có dữ liệu";
        hienThiKetQua("Đã xóa thông tin hiển thị.", false);
        ketQua.classList.replace("alert-info", "alert-success");
    });
})();
