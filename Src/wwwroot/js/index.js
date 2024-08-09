const toastEl = $("#toast");
if (toastEl.length) {
	const toast = new bootstrap.Toast(toastEl);
	toast.show();
}
