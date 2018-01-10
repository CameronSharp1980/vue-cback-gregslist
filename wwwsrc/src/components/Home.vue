<template>
  <div class="home">
    <h1>HOME</h1>
    <!-- current user is {{currentUser.id}} -->
    <div>
      <div class="categoryButtons">
        <button @click="toggleSearchCategories">Show Search Categories</button>
        <div v-if=showSearchCategories>
          <button @click="getAll('autos')">Get Autos</button>
          <button @click="getAll('animals')">Get Animals</button>
          <button @click="getAll('properties')">Get Properties</button>
        </div>
      </div>
      <div class="listingFormButtons">
        <button @click="toggleListingButtons">Post New Listing</button>
        <div v-if=showListingButtons>
          <button @click="toggleListingForm('submit', 'autos')">List New Auto</button>
          <button @click="toggleListingForm('submit', 'animals')">List New Animal</button>
          <button @click="toggleListingForm('submit', 'properties')">List New Property</button>
        </div>
      </div>
      <div v-if="showListingForm">
        <ListingForm></ListingForm>
      </div>

      <div v-if="showSearchResults">
        <div class="col-sm-3 thumbnail" v-for="result in searchResults">
          <img :src="result.imageURL"> {{result.title}} ${{result.price}}
          <div v-if="currentUser.id === result.creatorId">
            <!-- add a category prop to all models that has it's category(ie. autos) and change 'autos' in removeListing to be result.category -->
            <button @click="removeListing('autos', result)">Remove</button>
            <button @click="toggleListingForm('update', 'autos')">Update</button>
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
        showSearchCategories: false,
        showListingForm: false,
        showSearchResults: false,
        showListingButtons: false
      }
    },
    mounted() {

    },
    methods: {
      logout() {
        this.$store.dispatch('logout')
      },
      toggleSearchCategories() {
        this.showSearchCategories = !this.showSearchCategories
      },
      toggleListingForm(formType, listingType) {
        this.showListingForm = !this.showListingForm
        this.$store.dispatch('changeFormState', { formType: formType, listingType: listingType })
        //dispatch category to store to change the form state
      },
      toggleListingButtons() {
        this.showListingButtons = !this.showListingButtons
      },
      getAll(strArg) {
        this.$store.dispatch('getAll', strArg)
        this.showSearchResults = !this.showSearchResults
      },
      removeListing(strArg, result) {
        this.$store.dispatch('removeListing', { strArg: strArg, result: result, currentUser: this.currentUser })
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
      ListingForm

    }
  }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>