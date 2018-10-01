var app = new Vue({
    el: '#main-app',
    data: {
        secLine: null,
        cryptoInfo: {
            info: null,
            loading: null,
            errored: false
        }

    },
    filters: {
        currencydecimal(value) {
            return value.toFixed(2);
        }
    },
    mounted() {
        axios
            .get('/Home/SecBlock')
            .then(response => {
                this.secLine = response.data;
            });
        this.getCryptoInfo();
        setInterval(
            function () {
                this.getCryptoInfo();
                console.log("Refresh Crypto");
            }.bind(this), 2000);
        

    },
    methods: {
        getCryptoInfo() {
            axios
                .get('https://api.coindesk.com/v1/bpi/currentprice.json')
                .then(response => {
                    this.cryptoInfo.info = response.data.bpi;
                })
                .catch(error => {
                    console.log(error);
                    this.cryptoInfo.errored = true;
                })
                .finally(() => this.cryptoInfo.loading = false);
        }

    }



});