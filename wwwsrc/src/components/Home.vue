<template>
  <div class="home">
    <h1>HOME</h1>
    <div>
      <button @click="togglePostCategories">+</button>
      <div v-if=showCategories>
        <AutosForm></AutosForm>
      </div>

    </div>
    <button @click="logout">LOGOUT</button>
  </div>
</template>

<script>
  import AutosForm from './AutosForm'
  export default {
    name: 'Home',
    data() {
      return {
        showCategories: false
      }
    },
    mounted() {

    },
    methods: {
      logout() {
        this.$store.dispatch('logout')
      },
      togglePostCategories() {
        showCategories = !showCategories
      }
    },
    computed: {

    },
    components: {
      AutosForm

    }
  }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>