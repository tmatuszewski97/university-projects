$(function () {
  $("form[name='contact-form']").validate({
    rules: {
      name: {
        required: true,
        minlength: 5,
      },

      email: {
        required: true,
        email: true,
      },

      content: {
        required: true,
        minlength: 20,
      },
    },
    messages: {
      name: "Wprowadź imię (przynajmniej 5 znaków)",
      email: "Proszę wprowadzić prawidłowy adres e-mail",
      content: "Napisz nam, czego dotyczy zgłoszenie (przynajmniej 20 znaków)",
    },
  });
});
