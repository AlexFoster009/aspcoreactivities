import React, {useState, useEffect} from 'react';
import Axios from "axios";
import './styles.css';
import {Header, Icon, List} from "semantic-ui-react";
import {IActivity} from "../models/activity";


/**
 * 
 * @constructor
 */

const App = () => {
    /*
        Create an array that has 2 elements. the state its self as well
        as a function.
     */
    const [activities, setActivities] = useState<IActivity[]>([]);
    
    useEffect(() => {
        // This will cal our API and use the setActivties function
        // To populate our state.
        
        Axios.get<IActivity>('http://localhost:5000/api/activities')
            .then((response) => {
               setActivities([response.data]);
            });
        
    }, []); // Empty array is paramount to stop a loop
    
        return (
            <div>
                <Header as='h2'>
                    <Icon name='users' />
                    <Header.Content>Activities</Header.Content>
                </Header>
                
                <List>
                    {activities.map((activity) => (
                        
                      <List.Item key={activity.id}>{activity.title}</List.Item>
                      
                        ))
                    }
                </List>
            </div>
        );
}

export default App;
