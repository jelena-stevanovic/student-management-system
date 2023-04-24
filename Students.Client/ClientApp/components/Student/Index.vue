<template>
  <section>
    <div class="mb-5">
      <h1 class="title">All Students</h1>
    </div>
    <div>
      <button class="btn btn-primary mb-2" @click="$router.push('students/create')">
        <icon icon="plus" class="mr-2"></icon>
        <span>Add Student</span>
      </button>
    </div>
    <icon v-if="loading" icon="spinner" spin></icon>
    <table v-else class="table">
      <thead>
        <tr>
          <th>Id</th>
          <th>FirstName</th>
          <th>LastName</th>
          <th>Enrollment Year</th>
          <th></th>
            <th></th>
            <th></th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="student in students" :key="student.studentId">
          <td>{{ student.studentId }}</td>
          <td>{{ student.firstName }}</td>
          <td>{{ student.lastName }}</td>
          <td>{{ student.enrollmentYear }}</td>
          <td>
              <button class="btn btn-info" v-on:click="viewStudent(student.studentId)">
                  View
                </button> </td>
            <td>
                <button class="btn btn-warning" v-on:click="editStudent(student.studentId)">
                    Edit
                </button>
            </td>
            <td>
                <button class="btn btn-danger" v-on:click="deleteStudent(student.studentId)">
                    Delete
                </button>
            </td>
        </tr>

      </tbody>
    </table>
  </section>
</template>

<script>
import axios from 'axios';

export default {
  name: 'StudentIndex',
  data() {
    return {
      loading: false,
      students: [],
    };
  },
  mounted() {
    this.getStudents();
  },
  methods: {
    getStudents() {
      this.loading = true;
      axios.get('/api/students')
        .then((data) => {
          this.students = data.data;
        })
        .catch((error) => {
          // eslint-disable-next-line no-console
          console.log('Error caught when getting students from the api:');
          // eslint-disable-next-line no-console
          console.log(error);
        })
        .then(() => {
          this.loading = false;
        });
    },
    viewStudent(id) {
      this.$router.push(`/students/${id}`);
    },
    editStudent(id) {
      this.$router.push(`/students/${id}/edit`);
    },
    deleteStudent(id) {
      axios.delete(`/api/students/${id}`)
        .then(() => {
          this.getStudents();
        })
        .catch((error) => {
          // eslint-disable-next-line no-console
          console.log('Error caught when deleting student from the api:');
          // eslint-disable-next-line no-console
          console.log(error);
        });
    },
  },
};
</script>
