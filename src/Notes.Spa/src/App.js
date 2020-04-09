import React, { useEffect } from 'react'
import { useDispatch } from 'react-redux'
import { initializeNotes } from './reducers/noteReducer'
import Notification from './components/Notification'
import NewNote from './components/NewNote'
import Notes from './components/Notes'
import Filter from './components/Filter'
import Button from './components/Button'

const App = () => {
  const dispatch = useDispatch()
  useEffect(() => {
    dispatch(initializeNotes())
  }, [dispatch])

  return (
    <div>
      <svg style={{ display: 'none' }}>
        <symbol id="plus" viewBox="0 0 281.488 281.488">
          <g>
            <path d="M140.744,0C63.138,0,0,63.138,0,140.744s63.138,140.744,140.744,140.744s140.744-63.138,140.744-140.744
                    S218.351,0,140.744,0z M140.744,263.488C73.063,263.488,18,208.426,18,140.744S73.063,18,140.744,18
                    s122.744,55.063,122.744,122.744S208.425,263.488,140.744,263.488z"></path>
            <path
              d="M210.913,131.744h-61.168V70.576c0-4.971-4.029-9-9-9s-9,4.029-9,9v61.168H70.576c-4.971,0-9,4.029-9,9s4.029,9,9,9h61.168
                    v61.168c0,4.971,4.029,9,9,9s9-4.029,9-9v-61.168h61.168c4.971,0,9-4.029,9-9S215.883,131.744,210.913,131.744z">
            </path>
          </g>
        </symbol>
      </svg>
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
              <Button 
                className="btn" 
                id="clear" 
                text="Clear all" />
            </div>
          </div>
        </footer>
      </div>
    </div>

  )
}

export default App