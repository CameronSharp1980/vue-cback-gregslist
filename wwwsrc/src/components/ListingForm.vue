<template>
    <div class="autos-form">
        <!-- try making v-if form inputs to be able to use this one form for all listings -->
        <form class="form" @submit.prevent="submitPosting">
            <div class="form-group">
                <label for="title">Title: </label>
                <input class="form-control" type="text" name="title" v-model='listing.title' required>
            </div>
            <div class="form-group" v-if="this.listingType == 'animals'">
                <label for="animalName">Name: </label>
                <input class="form-control" type="text" name="animalName" v-model='listing.animalName' required>
            </div>
            <div class="form-group" v-if="this.listingType == 'properties'">
                <label for="zoning">Zoning: </label>
                <input class="form-control" type="text" name="zoning" v-model='listing.zoning' required>
            </div>
            <div class="form-group" v-if="this.listingType == 'properties'">
                <label for="squarefootage">Square Footage: </label>
                <input class="form-control" type="text" name="squarefootage" v-model='listing.squarefootage' required>
            </div>
            <div class="form-group" v-if="this.listingType == 'autos'">
                <label for="make">Make: </label>
                <input class="form-control" type="text" name="make" v-model='listing.make' required>
            </div>
            <div class="form-group" v-if="this.listingType == 'autos'">
                <label for="model">Model: </label>
                <input class="form-control" type="text" name="model" v-model='listing.model' required>
            </div>
            <div class="form-group" v-if="this.listingType == 'animals'">
                <label for="species">Species: </label>
                <input class="form-control" type="text" name="species" v-model='listing.species' required>
            </div>
            <div class="form-group" v-if="this.listingType == 'animals'">
                <label for="breed">Breed: </label>
                <input class="form-control" type="text" name="Breed" v-model='listing.breed' required>
            </div>
            <div class="form-group" v-if="this.listingType == 'autos'">
                <label for="year">Year: </label>
                <input class="form-control" type="text" name="year" v-model='listing.year' required>
            </div>
            <div class="form-group" v-if="this.listingType == 'animals'">
                <label for="age">Age: </label>
                <input class="form-control" type="text" name="age" v-model='listing.age' required>
            </div>
            <div class="form-group" v-if="this.listingType == 'properties'">
                <label for="yearbuilt">Year Built: </label>
                <input class="form-control" type="text" name="yearbuilt" v-model='listing.yearBuilt' required>
            </div>
            <div class="form-group">
                <label for="color">Color: </label>
                <input class="form-control" type="text" name="color" v-model='listing.color' required>
            </div>
            <div class="form-group">
                <label for="listingDescription">Description: </label>
                <input class="form-control" type="text" name="listingDescription" v-model='listing.listingDescription' required>
            </div>
            <div class="form-group">
                <label for="listingLocation">Location: </label>
                <input class="form-control" type="text" name="listingLocation" v-model='listing.listingLocation' required>
            </div>
            <div class="form-group" v-if="this.listingType == 'animals'">
                <label for="medicalConcerns">Medical Concerns: </label>
                <input class="form-control" type="text" name="medicalConcerns" v-model='listing.medicalConcerns' required>
            </div>
            <div class="form-group">
                <label for="imageURL">ImageURL: </label>
                <input class="form-control" type="text" name="imageURL" v-model='listing.imageURL' required>
            </div>
            <div class="form-group">
                <label for="price">Price: </label>
                <input class="form-control" type="text" name="price" v-model='listing.price' required>
            </div>
            <div class="form-group" v-if="formType == 'submit'">
                <button type="submit">Submit</button>
            </div>
            <div class="form-group" v-if="formType == 'update'">
                <button type="submit">Update</button>
            </div>
        </form>
    </div>
</template>

<script>
    export default {
        name: 'listingform',
        data() {
            return {
                listing: {
                    title: '',
                    animalName: '',
                    zoning: '',
                    squarefootage: '',
                    make: '',
                    model: '',
                    species: '',
                    breed: '',
                    year: '',
                    age: '',
                    yearBuilt: '',
                    color: '',
                    listingDescription: '',
                    listingLocation: '',
                    medicalConcerns: '',
                    imageURL: '',
                    price: ''
                }
            }
        },
        methods: {
            submitPosting() {
                console.log(this.currentUser)
                if (this.formType == "submit") {
                    this.$store.dispatch('submitPosting', { listing: this.listing, listingType: this.listingType, creatorId: this.currentUser.id })
                } else {
                    this.$store.dispatch('updatePosting', { listing: this.listing, listingType: this.listingType, creatorId: this.currentUser.id })
                }
            }

        },
        computed: {
            currentUser() {
                return this.$store.state.user
            },
            listingType() {
                return this.$store.state.listingType
            },
            formType() {
                return this.$store.state.formType
            }
        }
    }

</script>

<style>
</style>