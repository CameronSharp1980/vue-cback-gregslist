<template>
  <div class="home">
    <h1>HOME</h1>
    <div>

      <button @click="togglePostCategories">+</button>
      <div v-if=showCategories>
        Categories go here
      </div>

      <button @click="toggleAutosForm">Show Autos Form</button>
      <div v-if="showAutosForm">
        <AutosForm></AutosForm>
      </div>

      <div v-if="showSearchResults">
        <div class="col-sm-3" v-for="result in results">
          {{result.Title}}
        </div>
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
        showCategories: false,
        showAutosForm: false,
        showSearchResults: false

      }
    },
    mounted() {

    },
    methods: {
      logout() {
        this.$store.dispatch('logout')
      },
      togglePostCategories() {
        this.showCategories = !this.showCategories
      },
      toggleAutosForm() {
        this.showAutosForm = !this.showAutosForm
      }
    },
    computed: {
      autos() {
        return this.$store.state.searchResults
      }
    },
    components: {
      AutosForm

    }
  }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>