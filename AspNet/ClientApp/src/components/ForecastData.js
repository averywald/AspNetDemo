import React, { Component } from "react";

export class ForecastData extends Component {
    
    constructor(props) {
        super(props); // call superclass "Component" constructor

        // define displayable data model
        this.state = {
            forecasts: [],
            loading: true
        };

        fetch('https://localhost:5001/api/forecasts')
            .then(response => response.json())
            .then(data => {
              this.setState({
                forecasts: data, // assign the data to the react component
                loading: false // not loading AJAX request anymore
              });
            });
    }

    static renderForecastsTable(forecasts) {
        return (
          <table className='table'>
            <thead>
              <tr>
                <th>Date</th>
                <th>Temp. (C)</th>
                <th>Temp. (F)</th>
                <th>Summary</th>
              </tr>
            </thead>
            <tbody>
              {forecasts.map(forecast =>
                <tr key={forecast.Id}>
                  <td>{forecast.dateFormatted}</td>
                  <td>{forecast.temperatureC}</td>
                  <td>{forecast.temperatureF}</td>
                  <td>{forecast.summary}</td>
                </tr>
              )}
            </tbody>
          </table>
        );
      }
    
      render() {
        let contents = this.state.loading
          ? <p><em>Loading...</em></p>
          : ForecastData.renderForecastsTable(this.state.forecasts);
    
        return (
          <div>
            <h1>Weather forecast</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {contents}
          </div>
        );
      }

}