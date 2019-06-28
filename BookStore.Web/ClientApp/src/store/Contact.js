const initialState = {
    contacts: [],
    loading: false,
    errors: {},
    forceReload: false
}

export const actionCreators = {
    requestContacts: () => async (dispatch, getState) => {

        const url = 'api/Contact/Contacts';
        const response = await fetch(url);
        const contacts = await response.json();
        dispatch({ type: 'FETCH_CONTACTS', contacts });
    },
    saveContact: contact => async (dispatch, getState) => {

        const url = 'api/Contact/SaveContact';
        const headers = new Headers();
        headers.append('Content-Type', 'application/json');
        const requestOptions = {
            method: 'POST',
            headers,
            body: JSON.stringify(contact)
        };
        const request = new Request(url, requestOptions);
        await fetch(request);
        dispatch({ type: 'SAVE_CONTACT', contact });
    },
    deleteContact: contactId => async (dispatch, getState) => {
        const url = 'api/Contact/DeleteContact/' + contactId;
        const requestOptions = {
            method: 'DELETE',
        };
        const request = new Request(url, requestOptions);
        await fetch(request);
        dispatch({ type: 'DELETE_CONTACT', contactId });
    }
};

export const reducer = (state, action) => {
    state = state || initialState;

    switch (action.type) {
        case 'FETCH_CONTACTS': {
            return {
                ...state,
                contacts: action.contacts,
                loading: false,
                errors: {},
                forceReload: false
            }
        }
        case 'SAVE_CONTACT': {
            return {
                ...state,
                contacts: Object.assign({}, action.contact),
                forceReload: true
            }
        }
        case 'DELETE_CONTACT': {
            return {
                ...state,
                contactId: action.contactId,
                forceReload: true
            }
        }
        default:
            return state;
    }
};
