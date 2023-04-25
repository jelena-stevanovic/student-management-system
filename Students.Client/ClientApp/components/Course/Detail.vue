<template>
    <div>
        <div class="mb-5">
            <h1 class="title">Create Course</h1>
        </div>
        <div class="row">
            <div class="col-md-4">
                <div class="form-group">
                    <label class="label">Course Id</label>
                    <input v-model="courseId" class="form-control" type="text" disabled />
                </div>
                <div class="form-group">
                    <label class="label">Course Name</label>
                    <input v-model="courseName" class="form-control" type="text" disabled />
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

                <div class="form-group is-grouped">
                    <div class="control">
                        <a class="button is-link is-light"
                           @click="$router.push('/courses')">
                            Back
                        </a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios';

export default {
  data() {
    return {
      courseId: '',
      courseName: '',
      enrolledStudents: [],
    };
  },
  computed: {
    id() {
      return this.$route.params.id;
    },
  },
  created() {
    axios
      .get(`/api/courses/${this.id}`)
      .then((res) => {
        this.courseId = res.data.courseId;
        this.courseName = res.data.courseName;
        this.enrolledStudents = res.data.studentCourses.map((sc) => sc.student);
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
