function lockedProfile() {
    const buttons = Array.from(document.querySelectorAll('button'));
    buttons.forEach((button) => button
        .addEventListener('click', onShowMore));

    function onShowMore(e) {
        const isLocked = e.target.parentNode.children[4].checked;
        const isTextHidden = e.target.parentNode.children[9];

        if (isLocked) {
            const isHidden = e.target.textContent === 'Show more';
            isTextHidden.style.display = isHidden ? 'block' : 'none';
            e.target.textContent = isHidden ? 'Hide it' : 'Show more';
        };
    };
}