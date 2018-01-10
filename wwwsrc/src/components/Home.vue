<template>
  <div class="home">
    <h1>HOME</h1>
    <!-- current user is {{currentUser.id}} -->
    <div>

      <button @click="togglePostCategories">+</button>
      <div v-if=showCategories>
        <button @click="getAll('autos')">Get Autos</button>
      </div>

      <button @click="toggleAutosForm">Show Autos Form</button>
      <div v-if="showAutosForm">
        <AutosForm></AutosForm>
      </div>

      <div v-if="showSearchResults">
        <div class="col-sm-3 thumbnail" v-for="result in searchResults">
          <img :src="result.imageURL"> {{result.title}} ${{result.price}}
          <div v-if="currentUser.id === result.creatorId">
            <button @click="removeListing('autos', result.id)">Remove</button>
          </div>
        </div>
      </div>

    </div>
    <div>
      <button @click="logout">LOGOUT</button>
    </div>
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
      },
      getAll(strArg) {
        this.$store.dispatch('getAll', strArg)
        this.showSearchResults = !this.showSearchResults
      },
      removeListing(strArg, result) {
        this.$store.dispatch('removeListing', { strArg: strArg, resultId: result })
      }
    },
    computed: {
      searchResults() {
        return this.$store.state.searchResults
      },
      currentUser() {
        return this.$store.state.user
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