import { StatusBar } from "expo-status-bar";
import { ActivityIndicator, StyleSheet, Text, View } from "react-native";
import MapView, { Marker, PROVIDER_GOOGLE } from "react-native-maps";
import {
  requestForegroundPermissionsAsync, //solikcitar permissao da localização
  getCurrentPositionAsync, //captura a localização atual
  watchPositionAsync, // captura a localização em tempos
  LocationAccuracy // precisão da captura
} from "expo-location";
import { useEffect, useRef, useState } from "react";

import MapViewDirections from "react-native-maps-directions";
import { mapsKey } from "./Utils/MapsKey";

export default function App() {
  const mapReference = useRef(null)

  const [finalPosition, setFinalPosition] = useState({
    latitude: -23.5068153,
    longitude: -46.5159653,
  })

  const [initialPosition, setInitialPosition] = useState(null);

  const CapturarLocalizacao = async () => {
    const { granted } = await requestForegroundPermissionsAsync();

    if (granted) {
      const currentPosition = await getCurrentPositionAsync();

      setInitialPosition(currentPosition);

      console.log(initialPosition);
    }
  };

  const RecarregarVisualizacaoMapa = async () => {
    if (mapReference.current && initialPosition) {
      await mapReference.current.fitToCoordinates(
        [
          { latitude: initialPosition.coords.latitude, longitude: initialPosition.coords.longitude },
          { latitude: finalPosition.latitude, longitude: finalPosition.longitude }
        ],
        { edgePadding: { top: 60, right: 60, bottom: 60, left: 60 }, animated: true }
      )
    }
  }

  useEffect(() => {
    CapturarLocalizacao();

    //capturar localmente
    watchPositionAsync({
      accuracy: LocationAccuracy.High,
      timeInterval: 1000,
      distanceInterval: 1
    }, async (response) => {
      await setInitialPosition(response)

      // mapReference.current?animateCamera({
      //   pitch: 60,
      //   center: response.coords
      // })
    })
  }, [1000]);

  useEffect(() => {
    RecarregarVisualizacaoMapa();
  }, [initialPosition]);

  return (
    <View style={styles.container}>
      {initialPosition !== null ? (
        <>
          <MapView
          ref={mapReference}
            initialRegion={{
              latitude: initialPosition.coords.latitude,
              longitude: initialPosition.coords.longitude,
              latitudeDelta: 0.005,
              longitudeDelta: 0.005,
            }}
            style={styles.map}
            customMapStyle={grayMapStyle}
            provider={PROVIDER_GOOGLE}
          >
            {/* criando um marcador no mapa */}
            <Marker
              coordinate={{
                latitude: initialPosition.coords.latitude,
                longitude: initialPosition.coords.longitude,
              }}
              title="Exemplo de local"
              description="Senai Paulo Antonio Skaf"
              pinColor="blue"

            // propriedade para alterar o ícone de localização
            // image={}
            />

            <MapViewDirections
              origin={initialPosition.coords}
              destination={{
                latitude: -23.5068153,
                longitude: -46.5159653,
                latitudeDelta: 0.005,
                longitudeDelta: 0.005,
              }}
              strokeWidth={5}
              strokeColor="#496DBA"
              apikey={mapsKey}
            />

            <Marker
              coordinate={{
                latitude: -23.5068153,
                longitude: -46.5159653,
              }}
              title="Exemplo de local"
              description="Senai Paulo Antonio Skaf"
              pinColor="red"

            // propriedade para alterar o ícone de localização
            // image={}
            />
          </MapView>
          {console.log(initialPosition)}
        </>
      ) : (
        <>
          <Text>Carregando...</Text>

          <ActivityIndicator />
        </>
      )}
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: "#fff",
    alignItems: "center",
    justifyContent: "center",
  },
  map: {
    flex: 1,
    width: "100%",
  },
});


const grayMapStyle = [
  {
    elementType: "geometry",
    stylers: [
      {
        color: "#E1E0E7",
      },
    ],
  },
  {
    elementType: "geometry.fill",
    stylers: [
      {
        saturation: -5,
      },
      {
        lightness: -5,
      },
    ],
  },
  {
    elementType: "labels.icon",
    stylers: [
      {
        visibility: "on",
      },
    ],
  },
  {
    elementType: "labels.text.fill",
    stylers: [
      {
        color: "#FBFBFB",
      },
    ],
  },
  {
    elementType: "labels.text.stroke",
    stylers: [
      {
        color: "#33303E",
      },
    ],
  },
  {
    featureType: "administrative",
    elementType: "geometry",
    stylers: [
      {
        color: "#fbfbfb",
      },
    ],
  },
  {
    featureType: "administrative.country",
    elementType: "labels.text.fill",
    stylers: [
      {
        color: "#fbfbfb",
      },
    ],
  },
  {
    featureType: "administrative.land_parcel",
    stylers: [
      {
        visibility: "on",
      },
    ],
  },
  {
    featureType: "administrative.locality",
    elementType: "labels.text.fill",
    stylers: [
      {
        color: "#fbfbfb",
      },
    ],
  },
  {
    featureType: "poi",
    elementType: "labels.text.fill",
    stylers: [
      {
        color: "#fbfbfb",
      },
    ],
  },
  {
    featureType: "poi.business",
    stylers: [
      {
        visibility: "on",
      },
    ],
  },
  {
    featureType: "poi.park",
    elementType: "geometry",
    stylers: [
      {
        color: "#66DA9F",
      },
    ],
  },
  {
    featureType: "poi.park",
    elementType: "labels.text",
    stylers: [
      {
        visibility: "on",
      },
    ],
  },
  {
    featureType: "poi.park",
    elementType: "labels.text.fill",
    stylers: [
      {
        color: "#fbfbfb",
      },
    ],
  },
  {
    featureType: "poi.park",
    elementType: "labels.text.stroke",
    stylers: [
      {
        color: "#1B1B1B",
      },
    ],
  },
  {
    featureType: "road",
    stylers: [
      {
        visibility: "on",
      },
    ],
  },
  {
    featureType: "road",
    elementType: "geometry.fill",
    stylers: [
      {
        color: "#C6C5CE",
      },
    ],
  },
  {
    featureType: "road",
    elementType: "labels.text.fill",
    stylers: [
      {
        color: "#FBFBFB",
      },
    ],
  },
  {
    featureType: "road.arterial",
    elementType: "geometry",
    stylers: [
      {
        color: "#ACABB7",
      },
    ],
  },
  {
    featureType: "road.highway",
    elementType: "geometry",
    stylers: [
      {
        color: "#8C8A97",
      },
    ],
  },
  {
    featureType: "road.highway.controlled_access",
    elementType: "geometry",
    stylers: [
      {
        color: "#8C8A97",
      },
    ],
  },
  {
    featureType: "road.local",
    elementType: "labels.text.fill",
    stylers: [
      {
        color: "#fbfbfb",
      },
    ],
  },
  {
    featureType: "transit",
    elementType: "labels.text.fill",
    stylers: [
      {
        color: "#fbfbfb",
      },
    ],
  },
  {
    featureType: "water",
    elementType: "geometry",
    stylers: [
      {
        color: "#8EA5D9",
      },
    ],
  },
  {
    featureType: "water",
    elementType: "labels.text.fill",
    stylers: [
      {
        color: "#fbfbfb",
      },
    ],
  },
];