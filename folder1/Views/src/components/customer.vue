<template>
  <div class="customer container">
    <div>
      <h1>Danh sách khách hàng</h1>
    </div>
    <div class="nav-bar">
      <button id ="btnAdd" class="btn btn-primary" v-on:click="showModalAdd()">Thêm mới</button>
    </div>
    <table class="table">
        <thead class="thead-dark">
          <tr>
            <th>Mã khách hàng</th>
            <th>Tên khách hàng</th>
            <th>Ngày sinh</th>
            <th>Thành phố</th>
            <th>Số điện thoại</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          <tr v-for=" (item, index) in listCustomer" v-bind:key="index">
            <td>{{item.customerCode}}</td>     
            <td>{{item.customerName}}</td>
            <td>{{item.birthday}}</td>
            <td>{{item.city}}</td>
            <td>{{item.mobile}}</td>
            <td>
              <button data-toggle="modal" class="btn btn-warning" v-on:click="showModalEdit(item)"> Sửa</button>
              <button data-toggle="modal" class="btn btn-danger" v-on:click="showModalDelete(item)">Xóa</button>
            </td>

          </tr>
        </tbody>
    </table>
    <modalDelete @getIdCustomer="deleteCustomer" :customer="customer"> </modalDelete>
    <modalEdit @getDataEd="editCustomer" :customer="customer"> </modalEdit>
    <modalAdd @getDataCus="addCustomer" > </modalAdd>
  </div>
  
</template>

<script>
import axios from 'axios'
import modalDelete from './modalDelete'
import modalAdd from './modalAdd'
import modalEdit from './modalEdit'
export default {
  name: 'customer',
  components:{
    modalDelete,
    modalAdd,
    modalEdit
  },
  data (){
    return{
        listCustomer: [],
        customer : {},
        ok: 200
    }  
  },
  methods: {

    showModalDelete(customer){
      this.customer = JSON.parse(JSON.stringify(customer));
      $('#modalDel').modal('toggle');
    },


    showModalEdit(customer){ 
      this.customer = JSON.parse(JSON.stringify(customer));
      $('#modalEdit').modal('toggle');
    },


    showModalAdd(){
      $('#modalAdd').modal('toggle');
    },

    /**
     * Hàm xóa khách hàng
     * @param : ID khách hàng cần xóa
     * Auth: NTNgoc
     * Created date: 4/6/2020
     */
     deleteCustomer(customer){    
       try {
        var id = customer.customerID;
        var res = axios.delete('https://localhost:44368/api/Customer/'+ id);
        var pos = this.listCustomer.findIndex(item => item.customerID == customer.customerID)
        if(res.status = this.ok){
          this.listCustomer.splice(pos, 1);
          swal(
            "Thông báo",
             "Xóa thành công", 
            "success")
        }
       } catch (error){
         console.error(error)
       }
        
    },


        /**
       * Hàm Thêm khách hàng
       * @param đối tượng customer chưa có thuộc tính customerID
       * Auth: NTNgoc
       * Created: 5/6/2020
       */
      async addCustomer(cus){
        try {
            var res = await axios.post('https://localhost:44368/api/Customer/', cus);
            if ( res.status = this.ok){
              this.listCustomer.splice(0,0,cus);
          swal(
            "Thông báo",
             "Thêm thành công", 
            "success")
            }
        } catch (error) {
          console.error(error);
        }
        
      },


      /**
       * Hàm sửa khách hàng
       * @param: ID khách hàng cần sửa, dữ liệu khách hàng sau khi sửa
       * Auth: NTNgoc
       * Created date: 5/6/2020
       */
      async editCustomer(cus){
        try{
          var res = await axios.put('https://localhost:44368/api/Customer/'+ cus.customerID, cus);
          var pos = this.listCustomer.findIndex(item => item.customerID == cus.customerID);
          if(res.status=  this.ok){
          this.listCustomer.splice(pos,1,cus)
          swal(
            "Thông báo",
             "Sửa thành công", 
            "success")
          }
        } catch (error) {
          console.error (error);
        }
        
               }
      },
 

      /**
       * Lấy dữ liệu khách hàng
       * Auth: NTNgoc
       * Created date: 4/6/2020
       */
      async created(){
          var res = await axios.get('https://localhost:44368/api/Customer');
          this.listCustomer = res.data;
      }

}
</script>

<style>
.container{
  width: 800px;
  background-color: #F2F2F2;
  height: 100vh;
}
.nav-bar{
float: right;
}
</style>