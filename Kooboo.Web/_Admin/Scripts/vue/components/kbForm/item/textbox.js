(function() {
  Kooboo.vue.component.kbFormItemTextbox = Vue.component(
    "kb-form-item-textbox",
    {
      props: {
        data: Object,
        name: String,
        rules: Array,
        placeholder: String
      },
      data() {
        return { fieldValue: "" };
      },
      watch: {
        fieldValue(value) {
          this.$emit("fieldValue", {
            invalid: this.$v.fieldValue.$invalid,
            value: value
          });
        }
      },
      mixins: [window.fieldValidateMixin],
      created() {
        this.fieldValue = this.data[this.name];
      },
      template: Kooboo.getTemplate(
        "/_Admin/Scripts/vue/components/kbForm/item/textbox.html"
      )
    }
  );
})();
