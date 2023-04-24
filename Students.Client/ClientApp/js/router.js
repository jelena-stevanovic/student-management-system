import VueRouter from 'vue-router';
import StudentIndex from '../components/Student/Index.vue';
import StudentStatusesIndex from '../components/StudentStatus/Index.vue';
import StudentCreate from '../components/Student/Create.vue';
import StudentDetail from '../components/Student/Detail.vue';

const routes = [
  {
    path: '/students',
    name: 'default',
    component: StudentIndex,
  },
  {
    path: '/statuses',
    name: 'student_statuses',
    component: StudentStatusesIndex,
  },
  {
    path: '/students/create',
    name: 'student_create',
    component: StudentCreate,
  },
  {
    path: '/students/:id',
    name: 'Student',
    component: StudentDetail,
  },
  {
    path: '/students/:id/edit',
    name: 'EditStudent',
    component: StudentCreate,
  },
];

export default new VueRouter({
  mode: 'history',
  routes,
  linkActiveClass: 'is-active', // apply bulma class when a router link is active
});
