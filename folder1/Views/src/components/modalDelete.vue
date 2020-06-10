<template>
    <div class="modal fade" id ="modalDel">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h1>Cảnh báo</h1>
                    <button type="button" class="close" data-dimiss = "modal"></button>
                </div>
                <div class="modal-body">
                    Bạn có chắc chắn muốn xóa nhân viên {{customer.customerName}}
                </div>
                <div class="modal-footer">
                    <button class="btn btn-danger" data-dismiss ='modal' v-on:click="getIdCustomer()">Xóa</button>
                    <button class="btn btn-primary" data-dismiss ='modal'>Hủy bỏ</button>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: 'modal',
    props: {
        customer: Object
    },
    data(){
        return{
            listCustomers:[]
        }
    },
    methods:{
        getIdCustomer(){
            this.$emit('getIdCustomer', this.customer)
        }
    }
}
</script>

<style>

</style>