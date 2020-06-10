
<template>
  <div class="modal fade" id = "modalEdit">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title">Chỉnh sửa thông tin khách hàng</h5>
              <button class="close" data-dismiss = 'modal'></button>
          </div>
          <div class="modal-body">
            <form action="">
              <div class="input-group">
                <span  class="input-group-text">Mã khách hàng</span>
                <input type="text" class="form-control" v-model="customer.customerCode">
              </div>
              <div class="space"></div>
              <div class="input-group">
                <span class="input-group-text">Tên khách hàng</span>
                <input type="text" class="form-control" v-model="customer.customerName">
              </div>
              <div class="space"></div>
              <div class="input-group">
                <span class="input-group-text">Ngày sinh</span>
                <input type="text" class="form-control" v-model="customer.birthday">
              </div>
              <div class="space"></div>
              <div class="input-group">
                <span class="input-group-text">Thành phố</span>
                <input type="text" class="form-control" v-model="customer.city">
              </div>
              <div class="space"></div>
              <div class="input-group">
                <span class="input-group-text">Số điện thoại</span>
                <input type="text" class="form-control" v-model="customer.mobile">
              </div>
              <div class="space"></div>
            </form>
          </div>
          <div class="modal-footer">
            <button class="btn btn-success" data-dismiss = 'modal' v-on:click="getDataEdit()">Lưu</button>
            <button class="btn btn-warning" data-dismiss = 'modal'>Lưu và thêm</button>
            <button class="btn btn-danger" data-dismiss = 'modal'>Hủy bỏ</button>

          </div>
        </div>
      </div>
  </div>
</template>

<script>
export default {
  name: 'modal',
    props: {
        customer : Object,
    },
    data(){
        return{
          listCustomer: []
        }
    },
    methods:{
      //Xử lí 
      getDataEdit(){
        this.$emit('getDataEd', this.customer)
      }
    },
    watch:{
    //khi có sự thay đổi dữ liệu trên component
    listEmployees(newVal, oldVal){
  
    }
  },
}
</script>

<style>
  .input-group-text{
    width: 150px;
  }
  .space{
    height:30px;
  }
</style>