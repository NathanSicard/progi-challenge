<template>
    <div class="bidCalculator-component">
        <h1>Bid Calculator</h1>
        <form class="bidCalculator-component__form">
            <div>
                <label>Price</label>
                <input type="number" min="0" step=".01" v-model="vehiclePrice" />
            </div>
            <div>
                <label>Type</label>
                <select v-model="vehicleType">
                    <option>Common</option>
                    <option>Luxury</option>
                </select>
            </div>
        </form>
        <div class="bidCalculator-component__breakdown">
            <h2>Breakdown</h2>
            <div v-if="post">
                <p class="bidCalculator-component__breakdown--basic">Basic Fee: {{ post.basicFee.toFixed(2) }}$</p>
                <p class="bidCalculator-component__breakdown--special">Special Fee: {{ post.specialFee.toFixed(2) }}$</p>
                <p class="bidCalculator-component__breakdown--association">Association Fee: {{ post.associationFee.toFixed(2) }}$</p>
                <p class="bidCalculator-component__breakdown--storage">Storage Fee: {{ post.storageFee.toFixed(2) }}$</p>
                <p class="bidCalculator-component__breakdown--total">TotalCost: {{ post.totalCost.toFixed(2) }}$</p>
            </div>
            <div v-else>
                <div v-if="errorMessage">
                    <h3>Please provide a valid price</h3>
                    <p>Reason: {{ errorMessage }}</p>
                </div>
            </div>
        </div>
    </div>
</template>

<script lang="ts" setup>
    import type { FeeBreakdown } from '@/models/FeeBreakdown';
    import { ref, watchEffect } from 'vue';

    // NOTE: This type is defined here because it is specific to this page.
    type Vehicle = {
        basePrice: number,
        vehicleType: string,
    };

    const vehiclePrice = ref(0);
    const vehicleType = ref('Common');
    const post = ref<FeeBreakdown | null>(null);
    const errorMessage = ref('');

    // NOTE: It may be preferable to create an API file to abstract the fetching logic from the view layer.
    const updateEstimate = (): void => {
        fetch('bid', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ basePrice: vehiclePrice.value, vehicleType: vehicleType.value } as Vehicle),
        })
            .then(r => {
                if (r.ok) {
                    return r.json();
                }
            })
            .then(json => {
                post.value = json as FeeBreakdown;
            });
    };

    watchEffect(() => {
        if(vehiclePrice.value < 0) {
            post.value = null;
            errorMessage.value = "Prices cannot be negative"
            return;
        }
        if(vehiclePrice.value * 100 != Math.floor(vehiclePrice.value * 100)) {
            post.value = null;
            errorMessage.value = "Prices can only have 2 decimals";
            return;
        }
        errorMessage.value = "";
        updateEstimate();
    })
</script>

<style scoped>

.bidCalculator-component__breakdown {
    height: 200px;
}

.bidCalculator-component__form label {
    margin-right: 0.25rem;
}
</style>