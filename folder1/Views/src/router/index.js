import Vue from 'vue'
import Router from 'vue-router'
import customer from '@/components/customer'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'customer',
      component: customer
    }
  ]
})
