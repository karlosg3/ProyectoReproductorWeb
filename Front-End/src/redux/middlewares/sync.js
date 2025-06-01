let syncQueue = [];
let isSyncing = false;

const processQueue = async () => {
    if (isSyncing || syncQueue.length === 0) return;

    isSyncing = true;
    const operation = syncQueue.shift();

    try {
        await api.post('/sync', operation);
        console.log('Synced:', operation);
    } catch (error) {
        console.error('Sync failed, retrying...', error);
        syncQueue.unshift(operation);
    } finally {
        isSyncing = false;
        setTimeout(processQueue, 5000);
    }
};

setInterval(processQueue, 60000);