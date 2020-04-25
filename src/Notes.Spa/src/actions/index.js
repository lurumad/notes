import notesService from "../services/notes";

export const NEW_NOTE = "NEW_NOTE";

export const createNote = (content) => {
  return async (dispatch) => {
    dispatch(loading());
    const note = {
      content,
      important: true,
    };
    const newNote = await notesService.create(note);
    dispatch({
      type: NEW_NOTE,
      data: newNote,
    });
    dispatch(loaded());
  };
};

export const TOGGLE_IMPORTANCE = "TOGGLE_IMPORTANCE";

export const toggleImportance = (note) => {
  return async (dispatch) => {
    dispatch(loading());
    const changedNote = { ...note, important: !note.important };
    await notesService.update(changedNote.id, changedNote);
    dispatch({
      type: TOGGLE_IMPORTANCE,
      data: changedNote,
    });
    dispatch(loaded());
  };
};

export const REMOVE_NOTE = "REMOVE_NOTE";

export const removeNote = (id) => {
  return async (dispatch) => {
    dispatch(loading());
    await notesService.remove(id);
    dispatch({
      type: REMOVE_NOTE,
      id,
    });
    dispatch(loaded());
  };
};

export const REMOVE_ALL_NOTES = "REMOVE_ALL_NOTES";

export const removeAllNotes = () => {
  return async (dispatch) => {
    dispatch(loading());
    await notesService.removeAll();
    dispatch({
      type: REMOVE_ALL_NOTES,
      data: [],
    });
    dispatch(loaded());
  };
};

export const INIT_NOTES = "INIT_NOTES";

export const initializeNotes = () => {
  return async (dispatch) => {
    dispatch(loading());
    const notes = await notesService.getAll();
    dispatch({
      type: INIT_NOTES,
      data: notes,
    });
    dispatch(loaded());
  };
};

export const SHOW_ALL_NOTES = "SHOW_ALL_NOTES";

export const setFilter = (value) => {
  return {
    type: SHOW_ALL_NOTES,
    showAll: value,
  };
};

export const LOADING = "LOADING";

export const loading = () => {
  return {
    type: LOADING,
    loading: true,
  };
};

export const LOADED = "LOADED";

export const loaded = () => {
  return {
    type: LOADED,
    loading: false,
  };
};

export const USER_FOUND = "USER_FOUND";

export const userFound = (user) => {
  return {
    type: USER_FOUND,
    payload: user,
  };
};

export const SILENT_RENEW_ERROR = "SILENT_RENEW_ERROR";

export const silentRenewError = (error) => {
  return {
    type: SILENT_RENEW_ERROR,
    payload: error,
  };
};

export const ACCESS_TOKEN_EXPIRED = "ACCESS_TOKEN_EXPIRED";

export const accessTokenExpired = () => {
  return {
    type: ACCESS_TOKEN_EXPIRED,
  };
};

export const ACCESS_TOKEN_EXPIRING = "ACCESS_TOKEN_EXPIRING";

export const accessTokenExpiring = () => {
  return {
    type: ACCESS_TOKEN_EXPIRING,
  };
};

export const USER_SIGN_OUT = "USER_SIGN_OUT";

export const userSignedOut = () => {
  return {
    type: USER_SIGN_OUT,
  };
};

export const USER_UNLOADED = "USER_UNLOADED";

export const userUnloaded = () => {
  return {
    type: USER_UNLOADED,
  };
};
