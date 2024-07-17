document.addEventListener('DOMContentLoaded', function () {
    // Dummy data for demonstration
    //const records = [
    //    { name: 'example.com', password: 'password123', date: '2024-07-17', type: 'website' },
    //    { name: 'user@example.com', password: 'password456', date: '2024-07-16', type: 'email' },
    //];

    const passwordTable = document.getElementById('passwordTable');
    const searchInput = document.getElementById('searchInput');
    const passwordForm = document.getElementById('passwordForm');
    const nameInput = document.getElementById('nameInput');
    const passwordInput = document.getElementById('passwordInput');
    const typeWebsite = document.getElementById('typeWebsite');
    const typeEmail = document.getElementById('typeEmail');

    function renderTable(records) {
        passwordTable.innerHTML = '';
        records.forEach(record => {
            const row = document.createElement('tr');
            row.innerHTML = `
                <td>${record.name}</td>
                <td class="hidden-password">${record.password}</td>
                <td>${record.date}</td>
            `;
            row.addEventListener('click', () => {
                const passwordCell = row.querySelector('td:nth-child(2)');
                passwordCell.classList.toggle('hidden-password');
            });
            passwordTable.appendChild(row);
        });
    }

    searchInput.addEventListener('input', () => {
        const query = searchInput.value.toLowerCase();
        const filteredRecords = records.filter(record => record.name.toLowerCase().includes(query));
        renderTable(filteredRecords);
    });

    passwordForm.addEventListener('submit', (event) => {
        event.preventDefault();
        const newRecord = {
            name: nameInput.value,
            password: passwordInput.value,
            date: new Date().toISOString().split('T')[0],
            type: typeWebsite.checked ? 'website' : 'email'
        };
        if (newRecord.type === 'email' && !/\S+@\S+\.\S+/.test(newRecord.name)) {
            alert('Please enter a valid email address.');
            return;
        }
        records.push(newRecord);
        renderTable(records);
        $('#passwordModal').modal('hide');
        passwordForm.reset();
    });

    renderTable(records);
});
