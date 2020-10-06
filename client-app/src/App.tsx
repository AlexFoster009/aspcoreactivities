import React, {Component} from 'react';
import Axios from "axios";
import './App.css';
import {Header, Icon, List} from "semantic-ui-react";

/*
    Class componenets allow use to have more control
    over state and lifeycle of our app.
    
    We aregoing to use state to store our data. then use that data to display
    in our view.
 */
class App extends Component {
    // When the componenet laods it will be an empty state, then when the component
    // it will set the values array to be used within the component.
    
    state = {
        values: []
    }
    
    componentDidMount(): void {
        // Get values from out .Net API.
        Axios.get('http://localhost:5000/api/values')
            .then((response) => {
                console.log(response)

                this.setState({
                    values: response.data
                })
            });
    }

    render(): React.ReactNode {
        return (
            <div>
                <Header as='h2'>
                    <Icon name='users' />
                    <Header.Content>Activities</Header.Content>
                </Header>
                
                <List>
                    {
                        this.state.values.map((value: any) => (
                          <List.Item key={value.id}>{value.name}</List.Item>
                        ))
                    }
                </List>
            </div>
        );
    }
}

export default App;
