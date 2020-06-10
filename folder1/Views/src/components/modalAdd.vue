
<template>
  <div class="modal fade" id = "modalAdd">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title">Thêm mới khách hàng</h5>
              <button class="close" data-dismiss = 'modal'></button>
          </div>
          <div class="modal-body">
            <form action="">
              <div class="input-group">
                <span  class="input-group-text">Mã khách hàng</span>
                <input type="text" class="form-control" v-model="cusCode" required >
              </div>
              <div class="space"></div>
              <div class="input-group">
                <span class="input-group-text">Tên khách hàng</span>
                <input type="text" class="form-control" v-model="cusName" required >
              </div>
              <div class="space"></div>
              <div class="input-group">
                <span class="input-group-text">Ngày sinh</span>
                <input type="text" class="form-control" v-model="birthday">
              </div>
              <div class="space"></div>
              <div class="input-group">
                <span class="input-group-text">Thành phố</span>
                <input type="text" class="form-control" v-model="city">
              </div>
              <div class="space"></div>
              <div class="input-group">
                <span class="input-group-text">Số điện thoại</span>
                <input type="text" class="form-control" v-model="mobile">
              </div>
              <div class="space"></div>
            </form>
          </div>
          <div class="modal-footer">
            <button class="btn btn-success" data-dismiss = 'modal' v-on:click="getdataCustomer(cus)">Lưu</button>
            <button class="btn btn-danger" data-dismiss = 'modal'>Hủy bỏ</button>

          </div>
        </div>
      </div>
  </div>
</template>

<script>
export default {
  name: 'modal',
    data(){
        return{
          cus: {},
          cusCode: '',
          cusName : '',
          birthday: '',
          city: '',
          mobile : ''

        }
    },
    methods:{
      getdataCustomer(cus){
        var cus = {};
        cus.customerCode = this.cusCode;
        cus.customerName = this.cusName;
        cus.birthday = this.birthday;
        cus.city = this.city;
        cus.mobile = this.mobile;
        //console.log( cus)
        //console.log("1")
          this.$emit('getDataCus',cus)   
      }

    }
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