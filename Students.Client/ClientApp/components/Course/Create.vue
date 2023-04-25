<template>
    <div>
        <div class="mb-5">
            <h1 class="title">Create Course</h1>
        </div>
        <div class="row">
            <div class="col-md-4">
                <form @submit.prevent="submitForm">
                    <div class="form-group">
                        <label class="label">Course Name</label>
                        <input v-model="courseName" class="form-control" type="text" />
                    </div>

                    <label class="label">Enrolled Students</label>
                    <table class="table">
                        <tbody>
                            <tr v-for="student in enrolledStudents" :key="student.studentId">
                                <td>{{ student.studentId }}</td>
                                <td>{{ student.firstName }}</td>
                                <td>{{ student.lastName }}</td>
                                <td> </td>
                            </tr>

                        </tbody>
                    </table>

                    <label class="label">Not Enrolled Students</label>
                    <table class="table">
                        <tbody>
                            <tr v-for="student in notEnrolledStudents" :key="student.studentId">
                                <td>{{ student.studentId }}</td>
                                <td>{{ student.firstName }}</td>
                                <td>{{ student.lastName }}</td>
                                <td>
                                    <input type="checkbox" @change="enroll(student)" /> Enroll
                                </td>
                            </tr>

                        </tbody>
                    </table>

                    <div class="form-group is-grouped">
                        <input type="submit" class="btn btn-primary" value="Submit" />
                        <div class="control">
                            <a class="button is-link is-light"
                               @click="$router.push('/courses')">
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
      courseName: '',
      enrolledStudents: [],
      toEnrollStudents: [],
      notEnrolledStudents: [],
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
      method('/api/courses', {
        courseID: this.idToEdit ?? 0,
        courseName: this.courseName,
        studentCourses: this.toEnrollStudents.map((s) => (
          {
            id: 0,
            courseId: this.idToEdit ?? 0,
            studentId: s.studentId,
          })),
      })
        .then(() => {
          this.$router.push('/courses');
        })
        .catch((error) => {
          // eslint-disable-next-line no-console
          console.log('Error caught when getting courses from the api:');
          // eslint-disable-next-line no-console
          console.log(error);
        });
    },
    enroll(student) {
      console.log(this.toEnrollStudents.length);
      if (this.toEnrollStudents.some((s) => s.studentId === student.studentId)) {
        this.toEnrollStudents.splice(this.toEnrollStudents.indexOf(student), 1);
        return;
      }
      this.toEnrollStudents.push(student);
    },
  },
  created() {
    axios
      .get('/api/students/')
      .then((res) => {
        this.notEnrolledStudents = res.data.filter(
          (student) => !this.students.some(
            (enrolledStudent) => enrolledStudent.studentId === student.studentId,
          ),
        );
      })
      .catch((error) => {
        // eslint-disable-next-line no-console
        console.log('Error caught when getting students from the api:');
        // eslint-disable-next-line no-console
        console.log(error);
      });

    if (!this.idToEdit) {
      return;
    }

    axios
      .get(`/api/courses/${this.idToEdit}`)
      .then((res) => {
        this.courseName = res.data.courseName;
        this.enrolledStudents = res.data.studentCourses.map((sc) => sc.student);
        this.notEnrolledStudents = this.notEnrolledStudents.filter(
          (ns) => !this.enrolledStudents.some((s) => s.studentId === ns.studentId),
        );
      })
      .catch((error) => {
        // eslint-disable-next-line no-console
        console.log('Error caught when getting course details from the api:');
        // eslint-disable-next-line no-console
        console.log(error);
      });
  },
};
</script>
