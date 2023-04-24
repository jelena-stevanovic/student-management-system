<template>
  <div>
    <div class="mb-5">
      <h1 class="title">Create Student</h1>
    </div>
    <div class="row">
      <div class="col-md-4">
        <form @submit.prevent="submitForm">
          <div class="form-group">
            <label class="label">FirstName</label>
            <input v-model="firstName" class="form-control" type="text" />
          </div>
          <div class="form-group">
            <label class="label">LastName</label>
            <input v-model="lastName" class="form-control" type="text" />
          </div>
          <div class="form-group">
            <label class="label">Enrollment Year</label>
            <input v-model="enrollmentYear" class="form-control" type="text" />
          </div>
            <div class="form-group">
                <label class="label">Student Number</label>
                <input v-model="studentNumber" class="form-control" type="text" />
            </div>
            <div class="form-group">
                <label class="label">Student Status</label>
                <select class="form-control" v-model="statusId" required>
                    <option v-for="option in options" :selected="option.id == statusId"
                            v-bind:value="option.id"
                            v-bind:key="option.id">
                        {{ option.name }}
                    </option>
                </select>
            </div>
          <div class="form-group is-grouped">
            <input type="submit" class="btn btn-primary" value="Submit"/>
            <div class="control">
              <a class="button is-link is-light"
                 @click="$router.push('/students')">
                Cancel
              </a>
            </div>
          </div>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  data() {
    return {
      firstName: '',
      lastName: '',
      enrollmentYear: '',
      statusId: '',
      studentNumber: '',
      options: [{ name: 'Redovan', id: 1 }, { name: 'Vanredan', id: 2 }],
    };
  },
  computed: {
    idToEdit() {
      return this.$route.params.id;
    },
  },
  methods: {
    submitForm() {
      let method = axios.post;
      if (this.idToEdit) {
        method = axios.put;
      }

      method('/api/students', {
        studentID: this.idToEdit ?? 0,
        firstName: this.firstName,
        lastName: this.lastName,
        enrollmentYear: this.enrollmentYear,
        statusId: this.statusId,
        studentNumber: this.studentNumber,
      })
        .then(() => {
          this.$router.push('/students');
        })
        .catch((error) => {
          // eslint-disable-next-line no-console
          console.log('Error caught when getting students from the api:');
          // eslint-disable-next-line no-console
          console.log(error);
        });
    },
  },
  created() {
    if (!this.idToEdit) {
      return;
    }
    axios
      .get(`/api/students/${this.idToEdit}`)
      .then((res) => {
        this.firstName = res.data.firstName;
        this.lastName = res.data.lastName;
        this.enrollmentYear = res.data.enrollmentYear;
        this.statusId = res.data.status?.statusId;
        this.studentNumber = res.data.studentNumber;
      })
      .catch((error) => {
        // eslint-disable-next-line no-console
        console.log('Error caught when getting student details from the api:');
        // eslint-disable-next-line no-console
        console.log(error);
      });
  },
};
</script>
