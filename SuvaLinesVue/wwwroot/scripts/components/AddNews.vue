<template>

    <div class="add-news clearfix" style="color:#777;">

        <h1>Add News</h1>
        <br />
        <br />


        <form v-on:submit.prevent="postArticle($event)" class="col-lg-12 clearfix">
            <div class="form-group col-lg-7">
                <label>Title</label>
                <input v-model="postData.title" class="form-control" type="text">
            </div>
            <div class="form-group col-lg-7">
                <label>Long Title</label>
                <input v-model="postData.longTitle" class="form-control" type="text">
            </div>
            <div class="form-group col-lg-12">
                <label>Article Text</label>
                <textarea v-model="postData.articleText" class="form-control" rows="10"></textarea>
            </div>

            <div class="form-group col-lg-7">
                <label>Group</label>
                <select v-model="postData.groupId" class="form-control">
                    <option v-for="option in groupType" v-bind:value="option.typeId">{{option.name}}</option>
                </select>
            </div>

            <div class="form-check col-lg-7" style="margin-bottom:30px;">
                <input v-model="postData.visible" type="checkbox" class="form-check-input">
                <label class="form-check-label">Visible</label>
            </div>


            <div class="form-group col-lg-8">
                <label style="display:block;">Please select image and upload before submitting news</label>
                <button type="button" @click="uploadImg" class="btn btn-primary">Upload</button>

                <input type="file" @change="onFileSelected" class="form-control-file" accept="image/*" style="display:inline-block;">
                <input v-model="postData.imgUrl" class="form-control" type="text" disabled style="margin-top:10px;">
            </div>

            <div class="form-group col-lg-4" style="height:300px;">
                <img v-bind:src="postData.imgUrl" style="max-width:100%; max-height:100%;"/>
            </div>

            <div class="form-group col-lg-7" style="margin-top:20px;">
                <button type="submit" class="btn btn-primary" v-bind:disabled="submitButton">Submit</button>
            </div>

        </form>
 
    </div>

</template>


<script>

    export default {
        data() {
            return {
                postData: {
                    title: "",
                    longTitle: "",
                    articleText: "",
                    groupId: 0,
                    visible: false,
                    imgUrl:""
                },
                submitButton: true,
                groupType: [],
                selectedFile: null
            }
        },
        mounted() {
            this.getGroup();
        },
        methods: {
            getGroup() {
                console.log("getGroup");
                this.axios
                    .get('/api/types?groupid=3')
                    .then(response => {
                        this.groupType = response.data;
                    })
                    .catch(error => {
                        console.log(error);
                    });

            },
            postArticle(e) {
                this.axios({
                    url: '/api/postarticle',
                    method: 'post',
                    params: this.postData
                }).then((response) => {                   
                    console.log(response);

                    this.postData.title = "";
                    this.postData.longTitle = "";
                    this.postData.articleText = "";
                    this.postData.groupId = 0;
                    this.postData.visible = false;
                    this.postData.imgUrl = "";
                    
                    this.selectedFile = null;
                    this.submitButton = true;

                    console.log("Article", "Successfuly posted");
                }
                ).catch(function (response) {
                    console.log(response);
                }); 
            },
            onFileSelected(e) {
                this.selectedFile = e.target.files[0];
            },
            uploadImg() {
                let fdata = new FormData();
                fdata.append('image', this.selectedFile, this.selectedFile.name)
                this.axios.post('/api/uploadimg', fdata, {
                    headers: {
                        'Content-Type': `multipart/form-data; boundary=${fdata._boundary}`,
                    }
                }).then((response) => {
                    if (response.status == 200) {
                        if (response.data && response.data.value && response.data.value.url) {
                            this.postData.imgUrl = response.data.value.url;
                            this.submitButton = false;
                        }
                    } else {
                        console.error("Upload Image", "Failed");        
                    }
                })


            }
           
        }
    }
</script>