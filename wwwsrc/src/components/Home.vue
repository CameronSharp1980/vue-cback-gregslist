<template>
  <div class="home">
    <h1>HOME</h1>
    <!-- current user is {{currentUser.id}} -->
    <div>

      <button @click="togglePostCategories">+</button>
      <div v-if=showCategories>
        <button @click="getAll('autos')">Get Autos</button>
      </div>

      <button @click="toggleListingForm('submit', 'auto')">Show Autos Form</button>
      <div v-if="showListingForm">
        <AutosForm></AutosForm>
      </div>

      <div v-if="showSearchResults">
        <div class="col-sm-3 thumbnail" v-for="result in searchResults">
          <img :src="result.imageURL"> {{result.title}} ${{result.price}}
          <div v-if="currentUser.id === result.creatorId">
            <!-- add a category prop to all models that has it's category(ie. autos) and change 'autos' in removeListing to be result.category -->
            <button @click="removeListing('autos', result)">Remove</button>
            <button @click="toggleListingForm('update', auto)">Update</button>
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
  import ListingForm from './ListingForm'
  export default {
    name: 'Home',
    data() {
      return {
        showCategories: false,
        showListingForm: false,
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
      toggleListingForm() {
        this.showListingForm = !this.showListingForm
        //dispatch autos to store to change the form state
      },
      getAll(strArg) {
        this.$store.dispatch('getAll', strArg)
        this.showSearchResults = !this.showSearchResults
      },
      removeListing(strArg, result) {
        this.$store.dispatch('removeListing', { strArg: strArg, result: result, currentUser: this.currentUser })
      },
      showUpdateListingForm() {

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