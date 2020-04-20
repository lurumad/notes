import React, { useEffect } from "react";
import { useDispatch } from "react-redux";
import { initializeNotes } from "./actions";
import Notification from "./components/Notification";
import NewNote from "./components/NewNote";
import Notes from "./components/Notes";
import Filter from "./components/Filter";
import Button from "./components/Button";
import Loading from "./components/Loading";

const App = () => {
  const dispatch = useDispatch();
  useEffect(() => {
    dispatch(initializeNotes());
  }, [dispatch]);

  return (
    <div>
      <Loading />
      <div className="wrapper">
        <div className="container">
          <div className="to-do">
            <Notification />
            <div className="to-do__inner">
              <NewNote />
            </div>
            <Notes />
          </div>
        </div>
        <footer className="footer">
          <div className="container">
            <div className="text-right">
              <Filter />
              <Button className="btn" id="clear" text="Clear all" />
            </div>
          </div>
        </footer>
      </div>
    </div>
  );
};

export default App;
