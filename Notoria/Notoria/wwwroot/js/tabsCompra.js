const triggerTabList = document.querySelectorAll('#myTab button');
triggerTabList.forEach(triggerEl => {
  const tabTrigger = new bootstrap.Tab(triggerEl);

  triggerEl.addEventListener('click', event => {
    event.preventDefault();
    tabTrigger.show();
  });
});

const totalPagar = document.getElementById('totalPagar');
const btnPago = document.getElementById('confirmarTransaccion');

var linkPago = btnPago.getAttribute('href');

const btn30c = document.getElementById('c30');
btn30c.addEventListener('click', function () {
  totalPagar.innerHTML = 'Total a pagar: $30';
  btnPago.setAttribute('href', linkPago + "?cantTrans=" + 30);
  const triggerEl = document.querySelector('#myTab button[data-bs-target="#confirmar"]');
  triggerEl.removeAttribute('disabled');
  bootstrap.Tab.getInstance(triggerEl).show();
});

const btn60c = document.getElementById('c60');
btn60c.addEventListener('click', function () {
  totalPagar.innerHTML = 'Total a pagar: $60';
  btnPago.setAttribute('href', linkPago + "?cantTrans=" + 60);
  const triggerEl = document.querySelector('#myTab button[data-bs-target="#confirmar"]');
  triggerEl.removeAttribute('disabled');
  bootstrap.Tab.getInstance(triggerEl).show();
});

const btn100c = document.getElementById('c100');
btn100c.addEventListener('click', function () {
  totalPagar.innerHTML = 'Total a pagar: $100';
  btnPago.setAttribute('href', linkPago + "?cantTrans=" + 100);
  const triggerEl = document.querySelector('#myTab button[data-bs-target="#confirmar"]');
  triggerEl.removeAttribute('disabled');
  bootstrap.Tab.getInstance(triggerEl).show();
});